using System;
using System.Collections.Generic;
using System.Drawing;
using MonoTouch.UIKit;
using DukappCore.BL.Records;
using DukappCore.BL.Managers;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace Dukapp
{
    public class BasketTableSrc:UITableViewSource
    {

        protected class BasketTableItem
        {
            public BasketTableItem(){ m_bmIDs = new List<int>(); }
            public string m_meal_name{ get; set;}// meal name
            public int m_weight{ get; set;}
            public string m_unit;
            public List<int> m_bmIDs;
        }
        protected Dictionary<int, BasketTableItem> m_mealDict;
        protected BasketTableItem[] m_tableItems;
        protected string cellIdentifier = "BasketCell";
		public List<NSIndexPath> m_selectedItems;

        public BasketTableSrc( BasketMealsRecord[] items )
        {
			repopulateSource(items);
        }

		public void repopulateSource(BasketMealsRecord[] items)
		{
			m_mealDict = new Dictionary<int, BasketTableItem>();
			m_selectedItems = new List<NSIndexPath>();
			foreach (BasketMealsRecord bmr in items)
			{
				//create new table item
				//BasketTableItem bti = new BasketTableItem();
				// get recipe record for meal
				RecipeMealsRecord rmr = RecipeManager.GetRecipeMealRecord(bmr.RecipeMealsID);
				// record fo each meal id
				BasketTableItem bti;
                string unit = "";
				m_mealDict.TryGetValue( rmr.MealID, out bti );
				if (bti == null)
				{
					bti = new BasketTableItem();
					MealRecord mr = MealManager.GetMeal(rmr.MealID);
					bti.m_meal_name = mr.Name;
                    //save units first
                    bti.m_unit = mr.MealDesc;
				}
				bti.m_weight += rmr.Qty;
				bti.m_bmIDs.Add(bmr.ID);
				m_mealDict[rmr.MealID] = bti;
			}
			m_tableItems = new BasketTableItem[m_mealDict.Count];
			m_mealDict.Values.CopyTo(m_tableItems,0);
		}

        public override int RowsInSection (UITableView tableview, int section)
        {
            return m_tableItems.Length;
        }

        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
        {
            var views = NSBundle.MainBundle.LoadNib ("BasketTWCell_iPhone", tableView, null);
            BasketTWCell cell = Runtime.GetNSObject (views.ValueAt (0)) as BasketTWCell;
            cell.m_bGrayBackgnd = indexPath.Row % 2 == 0 ? true : false;
            cell.update(indexPath.Row);
            int qty = m_tableItems[indexPath.Row].m_weight;
            cell.UpdateCell(m_tableItems[indexPath.Row].m_meal_name, (qty > 0 ? qty.ToString() + " " : "")
                + m_tableItems[indexPath.Row].m_unit);
            return cell;
        }

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//[Take Row]
			BasketTWCell cell = tableView.CellAt(indexPath) as BasketTWCell;
			if( cell != null )
			{
				tableView.DeselectRow(indexPath, false);
				if (cell.m_bChecked)
					m_selectedItems.Add(indexPath);
				else
					m_selectedItems.Remove(indexPath);
			}
		}

		public void RemoveCheckedItems()
		{
			List<BasketTableItem> items = new List<BasketTableItem>(m_tableItems);
			foreach (NSIndexPath item in m_selectedItems)
			{
				foreach (int id in m_tableItems[item.Row].m_bmIDs)
					BasketManager.DeleteBasketRecord(id);

				items.Remove(m_tableItems[item.Row]);
			}
			m_tableItems = items.ToArray();
		}

		public override void WillDisplay (UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
		{
			UIView cellBackgroundView = new UIView(new RectangleF(0, 0, cell.Bounds.Width, cell.Bounds.Height));
			cell.BackgroundView = cellBackgroundView;

			UIView selectedView = new UIView(new RectangleF(0, 0, cell.Bounds.Width, cell.Bounds.Height));
			selectedView.BackgroundColor = cellBackgroundView.BackgroundColor;
			cell.SelectedBackgroundView = selectedView;
		}

        public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
        {
            return 61;
        }

    }
}

