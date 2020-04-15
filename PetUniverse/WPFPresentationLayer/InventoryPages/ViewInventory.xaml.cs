﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogicLayer;
using LogicLayerInterfaces;
using DataTransferObjects;
using PresentationUtilityCode;

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// Creator: Tener karar
    /// Created: 2020/02/7
    /// Approver: Brandyn T. Coverdill
    ///
    /// The main presentaion layer for  item class
    /// Contains all methods for performing basic item functions
    /// </summary>

    public partial class ViewInventory : Page
    {
        private IItemManager _itemManager;
        private IManageBackstockRecords StockManger;
        private Item item;
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this constrctor method mainwindow class 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        public ViewInventory()
        {
            InitializeComponent();
            StockManger = new ManageBackstockRecords();
            _itemManager = new ItemManager();
            item = new Item();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/03
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// This click event opens the view item detail screen.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Zach Behrensmeyer  
        /// Updated: 4/13/2020
        /// Update: Moved from ViewInventory page
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewItem_Click(object sender, RoutedEventArgs e)
        {
            Item item = (Item)DGViewDatat.SelectedItem;
            if (DGViewDatat.SelectedItem != null)
            {
                this.NavigationService?.Navigate(new ViewItemDetail(item));
            }
            else
            {
                "Please pick an item to view.".ErrorMessage();
            }
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this event for main window class 
        /// desplay the item in the screen item  
        /// </summary>
        ///
        /// <remarks>
        /// Updater Matt Deaton
        /// Updated: 2020-03-07 
        /// Update: Removed Column 3 to insure the Shelter Threshold didn't show up in Data Grid
        /// </remarks>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGViewDatat.ItemsSource = StockManger.getPetsInBackRoom();
            DGViewDatat.Columns.RemoveAt(3);

        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver:  Steven Cardona
        /// 
        /// this method creating a list to holde item list
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool result = StockManger.EditItemLocation(Convert.ToInt32(txtItemID.Text),
                 Convert.ToInt32(txtItemLocation.Text), Convert.ToInt32(txtNewItemLocation.Text));

                lblItemAdd.Content = "The item location updated.";
                txtItemLocation.Text = txtNewItemLocation.Text;
                txtNewItemLocation.Text = "";
            }
            catch (Exception)
            {
                lblItemAdd.Content = "Please enter a proper item location.";
            }
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver:  Brandyn T. Coverdill
        /// 
        /// this method  for show update loction and Hiding item view
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            DGViewDatat.UnselectAll();
            txtItemID.Text = "";
            txtItemName.Text = "";
            txtItemLocation.Text = "";
            txtNewItemLocation.Text = "";
            txtItemDescription.Text = "";
            txtItemCount.Text = "";

            canViewItems.Visibility = Visibility.Visible;
            canEditItemsLocation.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver:  Brandyn T. Coverdill
        /// 
        /// Auto generated columns method
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGViewDatat_AutoGeneratedColumns(object sender, EventArgs e)
        {
            // this fill all availalbe space with available columns
            foreach (var column in this.DGViewDatat.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this event for main window class 
        /// desplay the item in the screen item  
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/13/2020
        /// Update: Added if item = null logic
        /// </remarks>
        private void btnUpdateItem_Click(object sender, RoutedEventArgs e)
        {
            item = (Item)DGViewDatat.SelectedItem;
            List<int> locations = null;

            if (item != null)
            {
                try
                {
                    locations = StockManger.getItemLocations(item.ItemID);
                    txtItemID.Text = item.ItemID.ToString();
                    txtItemName.Text = item.ItemName;
                    txtItemLocation.Text = locations[0].ToString();
                    txtNewItemLocation.Text = "";
                    txtItemDescription.Text = item.Description;
                    txtItemCount.Text = locations.Count.ToString();

                }
                catch (Exception)
                {
                    locations = new List<int>();
                }


                canViewItems.Visibility = Visibility.Hidden;
                canEditItemsLocation.Visibility = Visibility.Visible;
            }
            else
            {
                WPFErrorHandler.ErrorMessage("No Item Selected. Please select one.");
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/01
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// This Button shows the Add Item Screen.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Zach Behrensmeyer  
        /// Updated: 4/13/2020
        /// Update: Moved from ViewInventory page
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new AddItems());
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/03/13
        /// Approver: Brandyn T. Coverdill
        /// Approver: Jesee Tomash
        ///
        /// Click event for deactivate button
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Zach Behrensmeyer  
        /// Updated: 4/13/2020
        /// Update: Moved from ViewInventory page
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeactivateItem_Click(object sender, RoutedEventArgs e)
        {
            Item item = (Item)DGViewDatat.SelectedItem;
            if (DGViewDatat.SelectedItem != null)
            {
                _itemManager.deactivateItem(item);
                DGViewDatat.ItemsSource = _itemManager.retrieveItemsByActive(true);
            }
            else
            {
                "Please pick an item to view.".ErrorMessage();
            }
        }
    }
}
