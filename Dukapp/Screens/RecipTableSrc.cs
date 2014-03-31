using System;
using MonoTouch.UIKit;
using DukappCore.BL.Managers;
using DukappCore.BL.Records;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using DukappCore.BL.Objects;

namespace Dukapp
{
	public class RecipTableSrc:UITableViewSource
	{
        protected RecipeRecord[] m_tableItems;
        protected string cellIdentifier = "RecipeTWCell";
        protected UIViewController m_parent_vc;
        public RecipTableSrc( RecipeSrcType type, UIViewController parent )
        {
            m_parent_vc = parent;
            List<RecipeRecord> recipesList = RecipeManager.GetRecipeRecords(type);
            m_tableItems = recipesList.ToArray();
        }

        public RecipTableSrc( DietPhaseId phase, UIViewController parent )
        {
            m_parent_vc = parent;
            List<RecipeRecord> recipesList = RecipeManager.GetRecipesForPhase(new DietPhase(phase));
            m_tableItems = recipesList.ToArray();
        }

        /*public void UpdateTableForPhase( RecipeSrcType type, DietPhaseId phase )
        {
        }*/

		public override int RowsInSection (UITableView tableview, int section)
		{
            return m_tableItems.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// request a recycled cell to save memory
            // RecipeTWCell cell = tableView.DequeueReusableCell (cellIdentifier) as RecipeTWCell;
			// if there are no cells to reuse, create a new one
            //if (cell == null)
            //{
                var views = NSBundle.MainBundle.LoadNib ("RecipeTWCell_iPhone", tableView, null);
                RecipeTWCell cell = Runtime.GetNSObject (views.ValueAt (0)) as RecipeTWCell;

                //cell = new RecipeTWCell((NSString)cellIdentifier, indexPath.Row); 
            cell.m_bChecked = m_tableItems[indexPath.Row].isFavourite == 1 ? true : false;
                cell.m_bGrayBackgnd = indexPath.Row % 2 == 0 ? true : false;
                cell.update(indexPath.Row);
            //}
            cell.UpdateRow( m_tableItems[indexPath.Row].RecipeName );
			return cell;
		}

        public override void AccessoryButtonTapped(UITableView tableView, NSIndexPath indexPath)
        {
            //List<RecipeMealsRecord> meals = RecipeManager.GetMealsForRecipe();
            MealsVC rec_meals = new MealsVC(m_tableItems[indexPath.Row], m_parent_vc );
            m_parent_vc.NavigationController.PushViewController (rec_meals, true);
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //[Take Row]
            RecipeTWCell cell = tableView.CellAt(indexPath) as RecipeTWCell;
            if( cell != null  )
            {
                if (cell.m_bWasChanged)
                {
                    RecipeRecord rec = RecipeManager.GetRecipeRecord(m_tableItems[indexPath.Row].ID);
                    rec.isFavourite = cell.m_bChecked ? 1 : 0;
                    RecipeManager.SaveRecipeRecord(rec);
                    cell.m_bWasChanged = false;
                }
                else
                {
                    // add pages
                    DukappPagedDataSource qsrc = new DukappPagedDataSource(2);
                    DukappPagedVC mp = new DukappPagedVC(qsrc);
                    MealsVC rec_meals = new MealsVC( m_tableItems[indexPath.Row], m_parent_vc );
                    HowToCookVC cook_vc = new HowToCookVC( m_tableItems[indexPath.Row] );
                    mp.m_pages.Add(rec_meals);
                    mp.m_pages.Add(cook_vc);
                    mp.SetViewControllers(new UIViewController[] { rec_meals }, UIPageViewControllerNavigationDirection.Forward,  true, null);
                    m_parent_vc.NavigationController.PushViewController (mp, true);
                }
            }
        }

        public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
        {
            return 61;
        }
	}
}

