using System;
using MonoTouch.UIKit;
using DukappCore.BL.Records;
using DukappCore.BL.Managers;
using MonoTouch.Foundation;
using System.Collections.Generic;
using MonoTouch.ObjCRuntime;


namespace Dukapp
{
    public class MealTableSrc:UITableViewSource
    {
        protected class MealTableItem
        {
            public MealTableItem(){}
            public MealRecord m_meal{ get; set;}
            public int m_qty{ get; set;}
            public bool m_bInBasket;
            public int m_RecMealID;
        }

        protected  List<MealTableItem> m_tableItems;
        protected string cellIdentifier = "MealCell";
        protected int m_recipeID;

        public MealTableSrc( RecipeMealsRecord[] items )
        {
            m_tableItems = new List<MealTableItem>();
            if (items.Length  != 0)
            {
                m_recipeID = items[0].RecipeID;
                foreach (RecipeMealsRecord rmr in items)
                {
                    MealRecord meal = MealManager.GetMeal(rmr.MealID);
                    BasketMealsRecord bmr = BasketManager.GetBasketRecipeRecord(rmr.ID);
                    if (meal != null)
                    {
                        MealTableItem mti = new MealTableItem();
                        mti.m_meal = meal;
                        mti.m_qty = rmr.Qty;
                        mti.m_bInBasket = bmr == null ? false : true;
                        mti.m_RecMealID = rmr.ID;
                        m_tableItems.Add(mti);
                    }
                }
            }
        }

        public override int RowsInSection (UITableView tableview, int section)
        {
            return m_tableItems.Count;
        }

        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
        {
            var views = NSBundle.MainBundle.LoadNib ("MealTWCell_iPhone", tableView, null);
            MealTWCell cell = Runtime.GetNSObject (views.ValueAt (0)) as MealTWCell;
            cell.m_bChecked = m_tableItems[indexPath.Row].m_bInBasket;
            cell.m_bGrayBackgnd = indexPath.Row % 2 == 0 ? true : false;
            cell.update(indexPath.Row);
            cell.UpdateCell(    m_tableItems[indexPath.Row].m_meal.Name, 
                                m_tableItems[indexPath.Row].m_qty.ToString(), 
                m_tableItems[indexPath.Row].m_meal.MealDesc);
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //[Take Row]
            MealTWCell cell = tableView.CellAt(indexPath) as MealTWCell;
            if( cell != null && cell.m_bWasChanged )
            {
                BasketMealsRecord bmr;
                if (cell.m_bChecked)
                { 
                    bmr = new BasketMealsRecord();
                    bmr.RecipeMealsID = m_tableItems[indexPath.Row].m_RecMealID;
                    BasketManager.SaveBasketRecord(bmr);
                }
                else
                {
                    bmr = BasketManager.GetBasketRecipeRecord(m_tableItems[indexPath.Row].m_RecMealID);
                    if( bmr != null )
                        BasketManager.DeleteBasketRecord(bmr.ID);
                }
                cell.m_bWasChanged = false;
            }
			tableView.DeselectRow(indexPath, false);
        }

        public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
        {
            return 61;
        }
    }
}

