using PizzaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaRestaurant.Services
{
    class Service
    {
        public tblGuest AddGuest(tblGuest guest)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblGuest newGuest = new tblGuest
                    {
                        GuestID = guest.GuestID,
                        GuestName = guest.GuestName,
                        GuestSurname = guest.GuestSurname,
                        EMail = guest.EMail,
                        JMBG = guest.JMBG
                    };

                    context.tblGuests.Add(newGuest);
                    context.SaveChanges();
                    guest.GuestID = newGuest.GuestID;
                    return guest;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public tblOrder AddOrder(tblOrder order)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblOrder newOrder = new tblOrder
                    {
                        OrderID = order.OrderID,
                        DateTimeOrder = order.DateTimeOrder,
                        Guest = order.Guest,
                        TotalPrice = order.TotalPrice,
                        OrderStatus = order.OrderStatus,
                        Archived = order.Archived
                    };

                    context.tblOrders.Add(newOrder);
                    context.SaveChanges();
                    order.OrderID = newOrder.OrderID;
                    return order;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public tblOrderItem AddOrderItem(tblOrderItem orderItem)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblOrderItem newOrderItem = new tblOrderItem
                    {
                        OrderItemID = orderItem.OrderItemID,
                        OrderName = orderItem.OrderName,
                        ProductName = orderItem.ProductName,
                        ProductPrice = orderItem.ProductPrice,
                        ProductQuantity = orderItem.ProductQuantity
                    };

                    context.tblOrderItems.Add(newOrderItem);
                    context.SaveChanges();
                    orderItem.OrderItemID = newOrderItem.OrderItemID;
                    return orderItem;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public tblGuest GetGuestJMBG(string JMBG)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblGuest emoloyee = (from e in context.tblGuests where e.JMBG.Equals(JMBG) select e).First();


                    return emoloyee;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblGuest GetGuestEmail(string email)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblGuest emoloyee = (from e in context.tblGuests where e.EMail.Equals(email) select e).First();


                    return emoloyee;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblOrder GetOrderID(int orderID)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblOrder order = (from e in context.tblOrders where e.OrderID.Equals(orderID) where e.Archived == 1 select e).First();


                    return order;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblGuest GetJMBG(string jmbg)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblGuest guest = (from e in context.tblGuests where e.JMBG.Equals(jmbg) select e).First();


                    return guest;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblProduct GetProductID(string product)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblProduct productID = (from e in context.tblProducts where e.ProductName.Equals(product) select e).First();

                    return productID;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblOrder GetAllOrderEmployee(int orderID)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblOrder order = (from e in context.tblOrders where e.OrderID.Equals(orderID) select e).First();

                    return order;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        public List<tblOrder> GetOrderID()
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    List<tblOrder> list = new List<tblOrder>();
                    list = (from x in context.tblOrders select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public List<tblOrder> GetOrderGuest(int guestID)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    List<tblOrder> list = new List<tblOrder>();
                    list = (from x in context.tblOrders where x.Guest == guestID where x.OrderStatus != 1 select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public List<tblOrder> GetOrderEmployee()
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    List<tblOrder> list = new List<tblOrder>();
                    list = (from x in context.tblOrders where x.OrderStatus == 1 select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public List<vwOrder> GetOrderItemGuest(int guestID)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    List<vwOrder> list = new List<vwOrder>();
                    list = (from x in context.vwOrders where x.Guest == guestID where x.OrderStatus != 1 orderby x.OrderName descending select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public List<vwOrder> GetOrderItemEmployeeArchive()
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    List<vwOrder> list = new List<vwOrder>();
                    list = (from x in context.vwOrders where x.Archived == 1 orderby x.OrderName descending select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public List<vwOrder> GetOrderItemGuestHoldOn(int guestID)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    List<vwOrder> list = new List<vwOrder>();
                    list = (from x in context.vwOrders where x.Guest == guestID where x.OrderStatus == 1 orderby x.OrderName descending select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public List<vwOrder> GetWaitingOrder(string jmbg)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    List<vwOrder> list = new List<vwOrder>();
                    list = (from x in context.vwOrders where x.JMBG == jmbg where x.OrderStatusID == 1 select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }


        public List<vwMenu> GetAllMenu()
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    List<vwMenu> list = new List<vwMenu>();
                    list = (from x in context.vwMenus select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public List<tblOrderItem> GetAllOrderItem()
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    List<tblOrderItem> list = new List<tblOrderItem>();
                    list = (from x in context.tblOrderItems select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public List<tblOrder> GetAllOrder()
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    List<tblOrder> list = new List<tblOrder>();
                    list = (from x in context.tblOrders select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public List<vwOrder> GetOrder(int orderID)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    List<vwOrder> list = new List<vwOrder>();
                    list = (from x in context.vwOrders where x.OrderID.Equals(orderID) select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public tblOrder GetOrderItemEmployee()
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblOrder emoloyee = (from e in context.tblOrders select e).First();


                    return emoloyee;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public void DeleteOrderItem(int orderID)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblOrderItem orderItemToDelete = (from r in context.tblOrderItems where r.OrderItemID == orderID select r).First();
                    context.tblOrderItems.Remove(orderItemToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
            }
        }

        public void DeleteOrder(int orderID)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblOrder orderToDelete = (from r in context.tblOrders where r.OrderID == orderID select r).First();
                    context.tblOrders.Remove(orderToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
            }
        }

        public bool IsOrderID(int orderID)
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    int result = (from x in context.tblOrderItems where x.OrderItemID == orderID select x.OrderItemID).FirstOrDefault();

                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return false;
            }
        }
    }
}
