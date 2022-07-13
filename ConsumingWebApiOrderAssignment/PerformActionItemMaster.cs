﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingWebApiOrderAssignment
{
    public class PerformActionItemMaster
    {
        public void setitem()
        {
            ItemMaster itemModel = new ItemMaster {Id=0, Name="Burger", Price=90, Quantity=300};  
            WebClient  webClient = new WebClient();
            webClient.Headers.Add("Content-Type:application/json");
            webClient.Headers.Add("Accept:application/json");
            var result = webClient.UploadString("https://localhost:7093/ItemMaster/AddItem", JsonConvert.SerializeObject(itemModel));
            Console.WriteLine(result);
        }
        private void Get()
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("https://localhost:7093/ItemMaster/GetItemList"); //URI  
                //Console.WriteLine(Environment.NewLine + result);
                List<ItemMaster> items = JsonConvert.DeserializeObject<List<ItemMaster>>(result);
                for(int i = 0; i < items.Count; i++)
                {
                   
                    var cus = JsonConvert.SerializeObject(items[i]);
                    Console.WriteLine(cus);
                    Console.WriteLine();
                }
            }

        }


        #region perform

        public void AddItem()
        {
        AddMore:
            ItemMaster itemMaster = new ItemMaster();
            try
            {
                Console.WriteLine("Enter The Item name ");
                itemMaster.Name = Console.ReadLine();

                Console.WriteLine("Enter The Item Price");
                itemMaster.Price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter The Item Quantity");
                itemMaster.Quantity = Convert.ToInt32(Console.ReadLine());
                if (itemMaster.Quantity > 0 && itemMaster.Price > 0 && itemMaster.Name != "")
                {
                    if (!ItemAlreadyExistOrNot(itemMaster.Name))
                    {
                        WebClient webClient = new WebClient();
                        webClient.Headers.Add("Content-Type:application/json");
                        webClient.Headers.Add("Accept:application/json");
                        var result = webClient.UploadString("https://localhost:7093/ItemMaster/AddItem/", JsonConvert.SerializeObject(itemMaster));
                        Console.WriteLine(result);
                        Console.WriteLine("Item Added Successfully");
                        Console.WriteLine();
                        Console.WriteLine("Do you Want to Add More Items");
                        Console.WriteLine("Press : 1");
                        int check = Convert.ToInt32(Console.ReadLine());
                        if (check == 1)
                        {
                            goto AddMore;
                        }




                    }
                    else
                    {
                        Console.WriteLine("This Item Already Exist  Use Another...");
                        goto AddMore;
                    }

                }
                else
                {
                    Console.WriteLine(" You Have left an Item As Blank Giave Value That Item");
                    goto AddMore;
                }


            }
            catch (FormatException ex)
            {
                Console.WriteLine("Enter valid Constraints ");
                goto AddMore;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void DeleteItem()
        {
        DeleteItemAgain:
            try
            {

                Console.WriteLine("ENter the Item Name To be Delete");
                string deleteItemName = Console.ReadLine();
                if (deleteItemName == "")
                {
                    Console.WriteLine("Enter the Valid Name It Can't Be Null");
                    goto DeleteItemAgain;
                }
                else
                {
                    if (ItemAlreadyExistOrNot(deleteItemName))
                    {
                        WebClient webClient = new WebClient();
                        webClient.Headers.Add("Content-Type:application/json");
                        webClient.Headers.Add("Accept:application/json");
                        var result=webClient.UploadString("https://localhost:7093/ItemMaster/DeleteItem/" + deleteItemName,"Delete","");

                        Console.WriteLine();
                        Console.WriteLine();

                        if (result == "\"Success\"")
                        {
                            Console.WriteLine("Item Delete SUccessfully !.");
                        }
                        else
                        {
                            Console.WriteLine("Error ):  Try Later");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Item Does Not Exist in Record ...\n Enter Valid Name");
                        goto DeleteItemAgain;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }

        }
        public void UpdateItem()
        {
        UpdateItemAgain:
            ItemMaster items = new ItemMaster();
            string oldtonewname;
            int? newPrice;
            decimal? NewQuantity;

            string updateItemName;
            try
            {
                Console.WriteLine("Enter The Item name That You Want to Update");
                updateItemName = Console.ReadLine();
                if (updateItemName == "")
                {
                    Console.WriteLine("Enter the Name It can't Be null");
                    goto UpdateItemAgain;
                }
                else
                {
                    if (ItemAlreadyExistOrNot(updateItemName))
                    {

                        try
                        {
                            Console.WriteLine("Enter the New Name Of Item That you Want to Update");
                            oldtonewname = Console.ReadLine();
                            if(ItemAlreadyExistOrNot(oldtonewname))
                            {
                                Console.WriteLine("Item already Exist in record Put Another Name");
                                goto UpdateItemAgain;
                            }
                            Console.WriteLine("Enter the New Price");
                            newPrice = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the New Quantity");
                            NewQuantity = Convert.ToDecimal(Console.ReadLine());
                            if (oldtonewname == "" || newPrice == null || NewQuantity == null)
                            {
                                Console.WriteLine("May Be You didn't fill all Option....   Please Fill Again");
                                goto UpdateItemAgain;

                            }
                            else
                            {
                                items.Name = oldtonewname;
                                items.Price = (int)newPrice;
                                items.Quantity = (int)NewQuantity;
                                WebClient webClient = new WebClient();
                                webClient.Headers.Add("Content-Type:application/json");
                                webClient.Headers.Add("Accept:application/json");
                                var result=webClient.UploadString("https://localhost:7093/ItemMaster/UpdateItem/" + updateItemName, "PUT", JsonConvert.SerializeObject(items));

                                Console.WriteLine("Item Update Successfully");
                                Console.WriteLine();
                                Console.WriteLine("Do you Want TO more update Items\n              Press: 1");
                                int chechk = Convert.ToInt32(Console.ReadLine());
                                if (chechk == 1)
                                {
                                    goto UpdateItemAgain;
                                }

                            }

                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.ToString() + "\nPlease Enter The Valid Credentials...");
                            goto UpdateItemAgain;

                        }
                        catch (Exception ex2)
                        {
                            Console.WriteLine(ex2.ToString() + "\ntry latter...");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Item Does Not Exist in Record...");
                        Console.WriteLine("Try Again ....");
                        goto UpdateItemAgain;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Try Latter ...");

            }

        }
            //private void ShowAllItem()
            //{
            //    try
            //    {
            //        var showitem = DbContextFile.itemMasters.ToList();
            //        if (showitem != null)
            //        {
            //            foreach (var item in showitem)
            //            {
            //                Console.WriteLine("Item Name    :" + item.Name);
            //                Console.WriteLine("Item Price   :" + item.Price);
            //                Console.WriteLine("Item Quantity:" + item.Quantity);
            //                Console.WriteLine();
            //                Console.WriteLine("========================================================");
            //                Console.WriteLine();
            //            }

            //        }
            //        else
            //        {
            //            Console.WriteLine("No Data Found...");
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //    }


            //}
            public bool ItemAlreadyExistOrNot(string ItemName)
        {
            WebClient web = new WebClient();
            web.Headers.Add("Content-Type:application/json");
            web.Headers.Add("Accept:application/json");
            var yesOrNot =web.DownloadString("https://localhost:7093/ItemMaster/IsItemExist?Name="+ ItemName);
            

            if (yesOrNot == "\"Yes\"")
            {
                return true;
            }

            return false;
        }
        private void ItemMasterMenu()

        {
            Console.WriteLine();
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("Add Item      Press :1                                          *");
            Console.WriteLine("Delete Item   Press :2                                          *");
            Console.WriteLine("update Item   Press :3                                          *");
            Console.WriteLine("Show All Item Press :4                                          *");
            Console.WriteLine("Exit          Press :5                                          *");
            Console.WriteLine("*****************************************************************");
            Console.WriteLine();
        }
        public void ItemMasterPortal()
        {

        Portal:
            ItemMasterMenu();
            int switch_on = Convert.ToInt32(Console.ReadLine());
            switch (switch_on)
            {
                case 1:
                    AddItem();
                    goto Portal;
                case 2:
                    DeleteItem();
                    goto Portal;
                case 3:
                    UpdateItem();
                    goto Portal;
                case 4:
                    //ShowAllItem();
                    Get();
                    goto Portal;
                case 5:

                    break;


                default:
                    Console.WriteLine("Wrong Choise Try Again");
                    goto Portal;
            }

        }
        #endregion
    }
}
