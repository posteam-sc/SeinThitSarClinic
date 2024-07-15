﻿using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Reporting.WinForms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using POS.APP_Data;
using System.Data;

namespace POS
{
    class Utility
    {
        /// <summary>
        /// Decrypting incomming file.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        public static void DecryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"myKey123";

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                MessageBox.Show("Decryption failed!", "Error");
            }
        }

        /// <summary>
        /// Encrypting incomming file.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        public static void EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"myKey123";
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;

                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                MessageBox.Show("Encryption failed!", "Error");
            }
        }

        /// <summary>
        /// Decrypt the input string ( Eg: EncryptString("ABC", string.Empty); )  
        /// </summary>
        public static string EncryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }

        /// <summary>
        /// Decrypt the input string ( Eg: DecryptString("LoBCnf0JCg8=", string.Empty); )  
        /// </summary>
        public static string DecryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }

        public static string GetSystemMACID()
        {
            string systemName = System.Windows.Forms.SystemInformation.ComputerName;
            try
            {
                ManagementScope theScope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
                System.Management.ObjectQuery theQuery = new System.Management.ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
                ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(theScope, theQuery);
                ManagementObjectCollection theCollectionOfResults = theSearcher.Get();

                foreach (ManagementObject theCurrentObject in theCollectionOfResults)
                {
                    if (theCurrentObject["MACAddress"] != null)
                    {
                        string macAdd = theCurrentObject["MACAddress"].ToString();
                        return macAdd.Replace(':', '-');
                    }
                }
            }
            catch (ManagementException e)
            {
            }
            catch (System.UnauthorizedAccessException e)
            {

            }
            return string.Empty;
        }

        public static Boolean IsRegister()
        {
            POSEntities entity = new POSEntities();
            string MacId = Utility.GetSystemMACID();
            Authorize currentKey = (from a in entity.Authorizes where a.macAddress == MacId select a).FirstOrDefault<Authorize>();
            if (currentKey != null)
            {
                return true;
            }
            return false;
        }

        //Calculate Exchange Rate
        public static decimal CalculateExchangeRate(int Id, decimal totalAmount)
        {
            POSEntities entity = new POSEntities();
            Currency currencyObj = entity.Currencies.FirstOrDefault(x => x.Id == Id);
            decimal value;
            if (currencyObj.CurrencyCode == "MMK")
            {
                value = (decimal)currencyObj.LatestExchangeRate * totalAmount;
                return value;
            }
            else if (currencyObj.CurrencyCode == "USD")
            {
                decimal num = (decimal)(((decimal)totalAmount / (decimal)currencyObj.LatestExchangeRate));
                value = Math.Ceiling(num * (decimal)Math.Pow(10, 2)) / (decimal)Math.Pow(10, 2);
                return value;
                //float remainder = (float)(((float)totalAmount % (float)currencyObj.LatestExchangeRate) );

                //long remainderD = (long)((totalAmount % (long)currencyObj.LatestExchangeRate));

                //float point = 0;
                ////while (remainder != 0)
                ////{
                //    point += (float)((remainder / 100) / 10);
                ////    remainder = (float)((remainder / 100)%10);
                ////}
                //num = (float)(String.Format("{0:0.00}", 123.4567));

                //value = (float)((totalAmount / currencyObj.LatestExchangeRate)) + (float)((((totalAmount % currencyObj.LatestExchangeRate) / 100) / 10));
                //return value;
            }
            return 0;
        }

        //Save TransactionId and current exchange rate
        public static void AddExchangeRateForTransaction(int currrencyId, string transId)
        {
            POSEntities entity = new POSEntities();
            Currency currencyObj = entity.Currencies.FirstOrDefault(x => x.Id == currrencyId);
            ExchangeRateForTransaction ExRTObj = new ExchangeRateForTransaction();
            ExRTObj.CurrencyId = currrencyId;
            ExRTObj.TransactionId = transId;
            ExRTObj.ExchangeRate = Convert.ToInt32(currencyObj.LatestExchangeRate);
            entity.ExchangeRateForTransactions.Add(ExRTObj);
            entity.SaveChanges();
        }

        //public static string FillZero(int id)
        //{
        //    string result = string.Empty;
        //    if (id < 10) result = "00000" + id;
        //    else if (id < 100) result = "0000" + id;
        //    else if (id < 1000) result = "000" + id;
        //    else if (id < 10000) result = "00" + id;
        //    else if (id < 100000) result = "0" + id;
        //    else if (id < 1000000) result = id.ToString();

        //    return result;
        //}

        public static void UpdateProductCode(string s, long p)
        {
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@ProductCode", s);
            paras[1] = new SqlParameter("@interestAmount", p);
        }


        #region Control Event
        //brand
        public static Boolean Brand_Combo_Control(ComboBox cboBrand)
        {
            bool _condition = false;
            POSEntities entity = new POSEntities();
            string _brandName = cboBrand.Text;

            if (_brandName != "Select" && _brandName != string.Empty)
            {
                var brand = (from c in entity.Brands where c.Name == _brandName select c).ToList();

                if (brand.Count <= 0)
                {
                    MessageBox.Show("Brand Name '" + cboBrand.Text + "' haven't registered yet!", "mPOS");
                    cboBrand.Focus();
                    _condition = true;
                }
            }
            return _condition;
        }

        //main category
        public static Boolean MainCategory_Combo_Control(ComboBox cboCategory)
        {
            bool _condition = false;
            POSEntities entity = new POSEntities();
            string _cagName = cboCategory.Text;

            if (_cagName != "Select" && _cagName != string.Empty)
            {
                var cag = (from c in entity.ProductCategories where c.Name == _cagName select c).ToList();

                if (cag.Count <= 0)
                {
                    MessageBox.Show("Category '" + cboCategory.Text + "' haven't registered yet!", "mPOS");
                    cboCategory.Focus();
                    _condition = true;
                }
            }
            return _condition;
        }


        //sub category
        public static Boolean SubCategory_Combo_Control(ComboBox cboSubCategory)
        {
            bool _condition = false;
            POSEntities entity = new POSEntities();
            string _subCagName = cboSubCategory.Text;

            if (_subCagName != "None" && _subCagName != "Select" && _subCagName != string.Empty)
            {
                var subCag = (from c in entity.ProductSubCategories where c.Name == _subCagName select c).ToList();

                if (subCag.Count <= 0)
                {
                    MessageBox.Show("Sub Category '" + cboSubCategory.Text + "' haven't registered yet!", "mPOS");
                    cboSubCategory.Focus();
                    _condition = true;
                }
            }
            return _condition;
        }

        //////tax
        ////public static Boolean Tax_Combo_Control(ComboBox cboTax)
        ////{
        ////    bool _condition = false;
        ////    POSEntities entity = new POSEntities();
        ////    string _tax = cboTax.Text;

        ////    if (_tax != "Select" && _tax != string.Empty)
        ////    {

        ////        var tax = (from c in entity.Taxes where c.Name == _tax  select c).ToList();

        ////        if (tax.Count <= 0)
        ////        {
        ////            MessageBox.Show("Tax '" + cboTax.Text + "' haven't registered yet!", "mPOS");
        ////            cboTax.Focus();
        ////            _condition = true;
        ////        }
        ////    }
        ////    return _condition;
        //// }

        //unit
        public static Boolean Unit_Combo_Control(ComboBox cboUnit)
        {
            bool _condition = false;
            POSEntities entity = new POSEntities();
            string _unit = cboUnit.Text;

            if (_unit != "Select" && _unit != string.Empty)
            {
                var tax = (from c in entity.Units where c.UnitName == _unit select c).ToList();

                if (tax.Count <= 0)
                {
                    MessageBox.Show("Unit '" + cboUnit.Text + "' haven't registered yet!", "mPOS");
                    cboUnit.Focus();
                    _condition = true;
                }
            }
            return _condition;
        }

        //product
        public static Boolean Product_Combo_Control(ComboBox cboProduct)
        {
            bool _condition = false;
            POSEntities entity = new POSEntities();
            string _productName = cboProduct.Text;

            if (_productName != "Select" && _productName != string.Empty)
            {
                var pro = (from c in entity.Products where c.Name == _productName select c).ToList();

                if (pro.Count <= 0)
                {
                    MessageBox.Show("Product Name '" + cboProduct.Text + "' haven't registered yet!", "mPOS");
                    cboProduct.Focus();
                    _condition = true;
                }
            }
            return _condition;
        }


        //supplier
        public static Boolean Supplier_Combo_Control(ComboBox cboSupplier)
        {
            bool _condition = false;
            POSEntities entity = new POSEntities();
            string _supName = cboSupplier.Text;

            if (_supName != string.Empty && _supName.Trim() != "Select")
            {
                var sup = (from c in entity.Suppliers where c.Name == _supName select c).ToList();

                if (sup.Count <= 0)
                {
                    MessageBox.Show("Supplier Name '" + cboSupplier.Text + "' haven't registered yet!", "mPOS");
                    cboSupplier.Focus();
                    _condition = true;
                }
            }
            return _condition;
        }

        //customer
        public static Boolean Customer_Combo_Control(ComboBox cboCustomer)
        {
            bool _condition = false;
            POSEntities entity = new POSEntities();
            string _cusName = cboCustomer.Text;

            if (_cusName != string.Empty && _cusName.Trim() != "Select")
            {
                if (_cusName != "None")
                {
                    var cus = (from c in entity.Customers where c.Name == _cusName select c).ToList();

                    if (cus.Count <= 0)
                    {
                        MessageBox.Show("Customer Name '" + cboCustomer.Text + "' haven't registered yet!", "mPOS");
                        cboCustomer.Focus();
                        _condition = true;
                    }

                }
            }
            return _condition;
        }
        #endregion

        #region Combo Bind Event
        //Customer
        public static void BindCustomer(ComboBox cboCustomer)
        {
            POSEntities entity = new POSEntities();
            List<Customer> customerList = new List<Customer>();
            Customer customerObj = new Customer();
            customerObj.Id = 0;
            customerObj.Name = "Select All";
            customerList.Add(customerObj);
            customerList = (from c in entity.Customers
                            join t in entity.Transactions on c.Id equals t.CustomerId
                            where (t.Type == "Credit" || t.Type == "CreditRefund" || t.Type == "Prepaid")
                            select c).Distinct().ToList();
            customerList.AddRange(entity.Customers.ToList());
            cboCustomer.DataSource = customerList;
            cboCustomer.DisplayMember = "Name";
            cboCustomer.ValueMember = "Id";
            cboCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //Supplier
        public static void BindSupplier(ComboBox cboSupplier)
        {
            POSEntities entity = new POSEntities();
            List<Supplier> supplierList = new List<Supplier>();
            Supplier supplierObj = new Supplier();
            supplierObj.Id = 0;
            supplierObj.Name = "Select All";
            supplierList.Add(supplierObj);
            supplierList.AddRange(entity.Suppliers.ToList());
            cboSupplier.DataSource = supplierList;
            cboSupplier.DisplayMember = "Name";
            cboSupplier.ValueMember = "Id";
            cboSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSupplier.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //Product
        public static void BindProduct(ComboBox cboProduct )
        {
            POSEntities entity = new POSEntities();
            List<Product> productList = new List<Product>();
            Product productObj = new Product();
            productObj.Id = 0;
            productObj.Name = "Select All";
            productList.Add(productObj);
            productList.AddRange(entity.Products.ToList());
            cboProduct.DataSource = productList;
            cboProduct.DisplayMember = "Name";
            cboProduct.ValueMember = "Id";
            cboProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProduct.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //CustomerType
        public static void BindCustomerType(ComboBox cboCustomerType)
        {
            POSEntities entity = new POSEntities();
            List<CustomerType> customerTypetList = new List<CustomerType>();
            CustomerType customerTypeObj = new CustomerType();
            customerTypeObj.Id = 0;
            customerTypeObj.Name = "Select";
            customerTypetList.Add(customerTypeObj);
            customerTypetList.AddRange(entity.CustomerTypes.ToList());
            cboCustomerType.DataSource = customerTypetList;
            cboCustomerType.DisplayMember = "Name";
            cboCustomerType.ValueMember = "Id";
            cboCustomerType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCustomerType.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //Room No
        public static void BindRoom(ComboBox cboRoom)
        {
            POSEntities entity = new POSEntities();
            List<Room> roomNoList = new List<Room>();
            Room roomNoObj = new Room();
            roomNoObj.Id = 0;
            roomNoObj.RoomNo = "Select";
            roomNoList.Add(roomNoObj);
            roomNoList.AddRange(entity.Rooms.ToList());
            cboRoom.DataSource = roomNoList;
            cboRoom.DisplayMember = "RoomNo";
            cboRoom.ValueMember = "Id";
            cboRoom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboRoom.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //Conversion Product
        public static void BindConversionProduct(ComboBox cboProduct, string unitType)
        {
            POSEntities entity = new POSEntities();
            List<Product> productList = new List<Product>();
            Product productObj = new Product();
            productObj.Id = 0;
            productObj.Name = "Select";
            productList.Add(productObj);
            productList.AddRange(entity.Products.Where(x=>x.UnitType == unitType).ToList());
            cboProduct.DataSource = productList;
            cboProduct.DisplayMember = "Name";
            cboProduct.ValueMember = "Id";
            cboProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProduct.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //Bind Reference Product
        public static void BindReferenceProduct(ComboBox cboProduct)
        {
            POSEntities entity = new POSEntities();
            List<Product> productList = new List<Product>();
            Product productObj = new Product();
            productObj.Id = 0;
            productObj.Name = "Select";
            productList.Add(productObj);
            productList.AddRange(entity.Products.ToList());
            cboProduct.DataSource = productList;
            cboProduct.DisplayMember = "Name";
            cboProduct.ValueMember = "Id";
            cboProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProduct.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

       //Cosignor
        public static void BindConsignor(ComboBox cboConsignor, Boolean IsAll=true)
        {
            POSEntities entity = new POSEntities();
            List<APP_Data.ConsignmentCounter> consignList = new List<APP_Data.ConsignmentCounter>();

            if (IsAll)
            {
                APP_Data.ConsignmentCounter conObj = new APP_Data.ConsignmentCounter();
                conObj.Id = 0;
                conObj.Name = "ALL";
                consignList.Add(conObj);
            }
            consignList.AddRange((from clist in entity.ConsignmentCounters select clist).ToList());
            cboConsignor.DataSource = consignList;
            cboConsignor.DisplayMember = "Name";
            cboConsignor.ValueMember = "Id";
            cboConsignor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboConsignor.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //Adjustment Type
        public static void Bind_AdjustmentType(ComboBox cboAdjType)
        {
            //  List<AdjustmentType> adjList = new List<AdjustmentType>();

            POSEntities entity = new POSEntities();
            List<APP_Data.AdjustmentType> adjList = new List<APP_Data.AdjustmentType>();
            //var adjList = (from a in entity.AdjustmentTypes select a).ToList();
            AdjustmentType adjusObj = new AdjustmentType();
            adjusObj.Id = 0;
            adjusObj.Name = "Select";
            adjList.Add(adjusObj);
       
            adjList.AddRange((from ajList in entity.AdjustmentTypes select ajList).ToList());
            cboAdjType.DataSource = adjList;
            cboAdjType.DisplayMember = "Name";
            cboAdjType.ValueMember = "Id";
            cboAdjType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboAdjType.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //Brand
        public static void BindBrand(ComboBox cboBrand)
        {
            POSEntities entity = new POSEntities();
            List<APP_Data.Brand> brandList = new List<APP_Data.Brand>();

            APP_Data.Brand brandObj = new APP_Data.Brand();
            brandObj.Id = 0;
            brandObj.Name = "Select";
            brandList.Add(brandObj);

            brandList.AddRange((from _brand in entity.Brands select _brand).ToList());
                cboBrand.DataSource = brandList;
            cboBrand.DisplayMember = "Name";
            cboBrand.ValueMember = "Id";
            cboBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboBrand.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        #endregion

        #region IsConsignmentPaid
        //For Consignment Product Paid or not Paid
        public static Boolean? IsConsignmentPaid(Product pro)
        {
            if (pro.IsConsignment == true)
            {
                return false;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region StockTransaction


        public static Boolean Stock_Transaction_Process(int _year, int _month, List<long> productIdList)
        {
            Boolean Success = true;

            Purchase_Process(_year, _month, productIdList);

            Refund_Process(_year, _month, productIdList);

            Sale_Process(_year, _month, productIdList);

            //Adjustment_Process(_year, _month, productIdList);
            Adjustment_Process(_year, _month, productIdList);

            Consignment_Process(_year, _month, productIdList);
            return Success;
        }

        //Purchase Process
        public static void Purchase_Process(int _year, int _month, List<long> productIdList)
        {
            POSEntities entity = new POSEntities();
            List<Stock_Transaction> _purchaseResult = Purchase_Balance(_year, _month, productIdList);



            //Purchase Save or Update
            foreach (var p in _purchaseResult)
            {
                string _tranDate = Month_Name(_month, _year);
                var _stockTranID = (from x in entity.StockTransactions
                                    where x.ProductId == p.ProductId
                                        && x.TranDate == _tranDate
                                    select x.StockTranId).FirstOrDefault();

                APP_Data.StockTransaction _stObject = new APP_Data.StockTransaction();
                if (_stockTranID == 0)
                {

                    _stObject.TranDate = _tranDate;
                    _stObject.ProductId = Convert.ToInt32(p.ProductId);
                    _stObject.Opening = Opening_Balance(_year, _month, Convert.ToInt64(p.ProductId));
                    _stObject.Purchase = p.Purchase;
                    _stObject.Refund = 0;
                    _stObject.Sale = 0;
                    _stObject.AdjustmentStockIn= 0;
                    _stObject.AdjustmentStockOut = 0;
                    _stObject.Consignment = 0;
                    _stObject.ConversionStockIn = 0;
                    _stObject.ConversionStockOut = 0;
                    _stObject.Month = _month;
                    _stObject.Year = _year;
                    entity.StockTransactions.Add(_stObject);
                    entity.SaveChanges();
                }
                else
                {

                    APP_Data.StockTransaction updateStockTransaction = (from s in entity.StockTransactions where s.StockTranId == _stockTranID select s).FirstOrDefault();
                    updateStockTransaction.Purchase = p.Purchase;
                    updateStockTransaction.Opening = Opening_Balance(_year, _month, Convert.ToInt64(p.ProductId));
                    entity.Entry(updateStockTransaction).State = EntityState.Modified;
                    entity.SaveChanges();
                }
            }

        }

        //Refund Process
        public static void Refund_Process(int _year, int _month, List<long> productIdList)
        {
            POSEntities entity = new POSEntities();
            List<Stock_Transaction> _refundResult = Refund_Balance(_year, _month, productIdList);

            //Refund Save or Update
            foreach (var r in _refundResult)
            {
                string _tranDate = Month_Name(_month, _year);
                var _stockTranID = (from x in entity.StockTransactions
                                    where x.ProductId == r.ProductId
                                        && x.TranDate == _tranDate
                                    select x.StockTranId).FirstOrDefault();


                if (_stockTranID == 0)
                {
                    APP_Data.StockTransaction _stObject = new APP_Data.StockTransaction();
                    _stObject.TranDate = _tranDate;
                    _stObject.ProductId = Convert.ToInt32(r.ProductId);
                    _stObject.Opening = Opening_Balance(_year, _month, Convert.ToInt64(r.ProductId));
                    _stObject.Purchase = 0;
                    _stObject.Refund = r.Refund;
                    _stObject.Sale = 0;
                    _stObject.AdjustmentStockIn = 0;
                    _stObject.AdjustmentStockOut = 0;
                    _stObject.Consignment = 0;
                    _stObject.ConversionStockIn = 0;
                    _stObject.ConversionStockOut = 0;
                    _stObject.Month = _month;
                    _stObject.Year = _year;
                    entity.StockTransactions.Add(_stObject);
                    entity.SaveChanges();
                }
                else
                {
                    APP_Data.StockTransaction updateStockTransaction = (from s in entity.StockTransactions where s.StockTranId == _stockTranID select s).FirstOrDefault();
                    updateStockTransaction.Refund = r.Refund;
                    updateStockTransaction.Opening = Opening_Balance(_year, _month, Convert.ToInt64(r.ProductId));
                    entity.Entry(updateStockTransaction).State = EntityState.Modified;
                    entity.SaveChanges();
                }
            }

        }

        //Sale Process
        public static void Sale_Process(int _year, int _month, List<long> productIdList)
        {
            POSEntities entity = new POSEntities();
            List<Stock_Transaction> _saleResult = Sale_Balance(_year, _month, productIdList);

            //Sale Save or Update
            foreach (var r in _saleResult)
            {
                string _tranDate = Month_Name(_month, _year);
                var _stockTranID = (from x in entity.StockTransactions
                                    where x.ProductId == r.ProductId
                                        && x.TranDate == _tranDate
                                    select x.StockTranId).FirstOrDefault();


                if (_stockTranID == 0)
                {
                    APP_Data.StockTransaction _stObject = new APP_Data.StockTransaction();
                    _stObject.TranDate = _tranDate;
                    _stObject.ProductId = Convert.ToInt32(r.ProductId);
                    _stObject.Opening = Opening_Balance(_year, _month, Convert.ToInt64(r.ProductId));
                    _stObject.Purchase = 0;
                    _stObject.Refund = 0;
                    _stObject.Sale = r.Sale;
                    _stObject.AdjustmentStockIn = 0;
                    _stObject.AdjustmentStockOut = 0;
                    _stObject.Consignment = 0;
                    _stObject.ConversionStockIn = 0;
                    _stObject.ConversionStockOut = 0;
                    _stObject.Month = _month;
                    _stObject.Year = _year;
                    entity.StockTransactions.Add(_stObject);
                    entity.SaveChanges();
                }
                else
                {
                    APP_Data.StockTransaction updateStockTransaction = (from s in entity.StockTransactions where s.StockTranId == _stockTranID select s).FirstOrDefault();
                    updateStockTransaction.Sale = r.Sale;
                    updateStockTransaction.Opening = Opening_Balance(_year, _month, Convert.ToInt64(r.ProductId));
                    entity.Entry(updateStockTransaction).State = EntityState.Modified;
                    entity.SaveChanges();
                }
            }

        }


        //Adjustment Process
        public static void Adjustment_Process(int _year, int _month, List<long> productIdList)
        {
            POSEntities entity = new POSEntities();
            List<Stock_Transaction> _adjustmentResult = Adjustment_Balance(_year, _month, productIdList);

            //Sale Save or Update
            foreach (var r in _adjustmentResult)
            {
                string _tranDate = Month_Name(_month, _year);
                var _stockTranID = (from x in entity.StockTransactions
                                    where x.ProductId == r.ProductId
                                        && x.TranDate == _tranDate
                                    select x.StockTranId).FirstOrDefault();


                if (_stockTranID == 0)
                {
                    APP_Data.StockTransaction _stObject = new APP_Data.StockTransaction();
                    _stObject.TranDate = _tranDate;
                    _stObject.ProductId = Convert.ToInt32(r.ProductId);
                    _stObject.Opening = Opening_Balance(_year, _month, Convert.ToInt64(r.ProductId));
                    _stObject.Purchase = 0;
                    _stObject.Refund = 0;
                    _stObject.Sale = 0;
                    if (r.AdjustmentQty < 0)
                    {
                        _stObject.AdjustmentStockOut = r.AdjustmentQty * -1;
                        _stObject.AdjustmentStockIn = 0;
                    }
                    else
                    {
                        _stObject.AdjustmentStockIn = r.AdjustmentQty;
                        _stObject.AdjustmentStockOut = 0;
                    }
                    
                    _stObject.Consignment = 0;
                    _stObject.ConversionStockIn = 0;
                    _stObject.ConversionStockOut = 0;
                    _stObject.Month = _month;
                    _stObject.Year = _year;
                    entity.StockTransactions.Add(_stObject);
                    entity.SaveChanges();
                }
                else
                {
                    APP_Data.StockTransaction updateStockTransaction = (from s in entity.StockTransactions where s.StockTranId == _stockTranID select s).FirstOrDefault();
                    if (r.AdjustmentQty < 0)
                    {
                        updateStockTransaction.AdjustmentStockOut = r.AdjustmentQty * -1;
                    }
                    else
                    {
                        updateStockTransaction.AdjustmentStockIn= r.AdjustmentQty;
                    }
                
                    updateStockTransaction.Opening = Opening_Balance(_year, _month, Convert.ToInt64(r.ProductId));
                    entity.Entry(updateStockTransaction).State = EntityState.Modified;
                    entity.SaveChanges();
                }
            }

        }

    

        //Consignment Process
        public static void Consignment_Process(int _year, int _month, List<long> productIdList)
        {
            POSEntities entity = new POSEntities();
            List<Stock_Transaction> _consignmentResult = Consignment_Balance(_year, _month, productIdList);

            //Sale Save or Update
            foreach (var r in _consignmentResult)
            {
                string _tranDate = Month_Name(_month, _year);
                var _stockTranID = (from x in entity.StockTransactions
                                    where x.ProductId == r.ProductId
                                        && x.TranDate == _tranDate
                                    select x.StockTranId).FirstOrDefault();


                if (_stockTranID == 0)
                {
                    APP_Data.StockTransaction _stObject = new APP_Data.StockTransaction();
                    _stObject.TranDate = _tranDate;
                    _stObject.ProductId = Convert.ToInt32(r.ProductId);
                    _stObject.Opening = Opening_Balance(_year, _month, Convert.ToInt64(r.ProductId));
                    _stObject.Purchase = 0;
                    _stObject.Refund = 0;
                    _stObject.Sale = 0;
                    _stObject.AdjustmentStockIn = 0;
                    _stObject.AdjustmentStockOut = 0;
                    _stObject.Consignment = Convert.ToInt32(r.Consignment);
                    _stObject.ConversionStockIn = 0;
                    _stObject.ConversionStockOut = 0;
                    _stObject.Month = _month;
                    _stObject.Year = _year;
                    entity.StockTransactions.Add(_stObject);
                    entity.SaveChanges();
                }
                else
                {
                    APP_Data.StockTransaction updateStockTransaction = (from s in entity.StockTransactions where s.StockTranId == _stockTranID select s).FirstOrDefault();
                    updateStockTransaction.Consignment = Convert.ToInt32(r.Consignment);
                    updateStockTransaction.Opening = Opening_Balance(_year, _month, Convert.ToInt64(r.ProductId));
                    entity.Entry(updateStockTransaction).State = EntityState.Modified;
                    entity.SaveChanges();
                }
            }

        }

        //Opening_Balance
        public static int Opening_Balance(int _year, int _month, long productId)
        {
            POSEntities entity = new POSEntities();
            int _openingBalance = 0;
            var _companyStartDate = Convert.ToDateTime(SettingController.Company_StartDate);

            //if (_year >= _companyStartDate.Year && _month > _companyStartDate.Month)
            //{
            int _preMonth = _month - 1;

            string tranDate = Month_Name(_preMonth, _year);


            List<long> productIdList = new List<long> { productId };

            //Purchase Balance
            List<Stock_Transaction> _purResult = Purchase_Balance(_year, _preMonth, productIdList);

            int _purchaseBalance = 0;
            if (_purResult.Count > 0)
            {
                _purchaseBalance = Convert.ToInt32(_purResult.Sum(x => x.Purchase));
            }

            //Refund Balance
            List<Stock_Transaction> _refundResult = Refund_Balance(_year, _preMonth, productIdList);

            int _refundBalance = 0;
            if (_refundResult.Count > 0)
            {
                _refundBalance = Convert.ToInt32(_refundResult.Sum(x => x.Refund));
            }


            //Sale Balance
            List<Stock_Transaction> _saleResult = Sale_Balance(_year, _preMonth, productIdList);

            int _saleBalance = 0;
            if (_saleResult.Count > 0)
            {
                _saleBalance = Convert.ToInt32(_saleResult.Sum(x => x.Sale));
            }


            //Adjustment Balance
            //List<Stock_Transaction> _AdjustmentResult = Adjustment_Balance(_year, _preMonth, productIdList);

            //int _AdjustmentBalance = 0;
            //if (_AdjustmentResult.Count > 0)
            //{
            //    _AdjustmentBalance = Convert.ToInt32(_AdjustmentResult.Sum(x => x.Adjustment));
            //}

            //Adjustment Balance
            List<Stock_Transaction> _adjustmentResult = Adjustment_Balance (_year, _preMonth, productIdList);

            int _AdjustmentBalance = 0;
            if (_adjustmentResult.Count > 0)
            {
                _AdjustmentBalance = Convert.ToInt32(_adjustmentResult.Sum(x => x.AdjustmentQty));
            }


            //Consignment Balance
            List<Stock_Transaction> _consignmentResult = Consignment_Balance(_year, _preMonth, productIdList);

            int _consignBalance = 0;
            if (_consignmentResult.Count > 0)
            {
                _consignBalance = Convert.ToInt32(_consignmentResult.Sum(x => x.Consignment));
            }

            //Opening Balance
            int? _preOpenBalance = 0;
            _preOpenBalance = (from o in entity.StockTransactions where o.TranDate == tranDate && o.ProductId == productId select o.Opening).FirstOrDefault();

            _preOpenBalance = _preOpenBalance == null ? 0 : _preOpenBalance;
            
            _openingBalance = Convert.ToInt32(_preOpenBalance + (_purchaseBalance + _refundBalance + _consignBalance) - (_saleBalance + _AdjustmentBalance));

            // }

            ////if (_openingBalance == 0)
            ////{
            ////    if (_year > _companyStartDate.Year)
            ////    {
            ////        var stockTranList = (from o in entity.StockTransactions where o.ProductId == productId select o).OrderByDescending(x => x.StockTranId).FirstOrDefault();

            ////        if (stockTranList != null)
            ////        {

            ////            _openingBalance = Convert.ToInt32(stockTranList.Opening + (stockTranList.Purchase + stockTranList.Refund + stockTranList.Consignment + stockTranList.AdjustmentStockIn) - (stockTranList.Sale + stockTranList.AdjustmentStockOut));
            ////        }
            ////    }
            ////    else if (_year == _companyStartDate.Year && _month > _companyStartDate.Month)
            ////    {
            ////       // var stockTranList = (from o in entity.StockTransactions where o.ProductId == productId select o).OrderByDescending(x => x.StockTranId).FirstOrDefault();
            ////        var stockTranList = (from o in entity.StockTransactions where o.ProductId == productId && ((o.Year < _year && o.Year <= _year) || (o.Year == _year) && (o.Year <= _year && o.Month < _month)) select o).OrderBy(x => x.Year).OrderByDescending(x => x.Month).FirstOrDefault();

            ////        if (stockTranList != null)
            ////        {

            ////            _openingBalance = Convert.ToInt32(stockTranList.Opening + (stockTranList.Purchase + stockTranList.Refund + stockTranList.Consignment + stockTranList.AdjustmentStockIn) - (stockTranList.Sale + stockTranList.AdjustmentStockOut));
            ////        }
            ////    }
            ////}


            var stockTranList = (from o in entity.StockTransactions where o.ProductId == productId && ((o.Year < _year && o.Year <= _year) || (o.Year == _year) && (o.Year <= _year && o.Month < _month)) select o).OrderBy(x => x.Year).OrderByDescending(x => x.Month).FirstOrDefault();

            if (stockTranList != null)
            {

                _openingBalance = Convert.ToInt32(stockTranList.Opening + (stockTranList.Purchase + stockTranList.Refund + stockTranList.Consignment + stockTranList.AdjustmentStockIn) - (stockTranList.Sale + stockTranList.AdjustmentStockOut));
            }
            return _openingBalance;
        }

        //check exist or not exist productid in stockTransaction table
        public static List<APP_Data.StockTransaction> Check_StockTransaction(List<long> productIdList, string tranDate)
        {
            POSEntities entity = new POSEntities();

            List<APP_Data.StockTransaction> _dataResult = (from e in entity.StockTransactions
                                                           where e.TranDate == tranDate
                                                           && productIdList.Contains(e.ProductId)

                                                           select e).ToList();
            return _dataResult;

        }

        public static string Month_Name(int _month, int _year)
        {
            string _tranDate = "";
            switch (_month)
            {
                case 1:
                    _tranDate = "Janauary" + "-" + _year.ToString();
                    break;
                case 2:
                    _tranDate = "February" + "-" + _year.ToString();
                    break;
                case 3:
                    _tranDate = "March" + "-" + _year.ToString();
                    break;
                case 4:
                    _tranDate = "April" + "-" + _year.ToString();
                    break;
                case 5:
                    _tranDate = "May" + "-" + _year.ToString();
                    break;
                case 6:
                    _tranDate = "June" + "-" + _year.ToString();
                    break;
                case 7:
                    _tranDate = "July" + "-" + _year.ToString();
                    break;
                case 8:
                    _tranDate = "August" + "-" + _year.ToString();
                    break;
                case 9:
                    _tranDate = "September" + "-" + _year.ToString();
                    break;
                case 10:
                    _tranDate = "October" + "-" + _year.ToString();
                    break;
                case 11:
                    _tranDate = "November" + "-" + _year.ToString();
                    break;
                case 12:
                    _tranDate = "December" + "-" + _year.ToString();
                    break;
            }
            return _tranDate;
        }

        //Purchase (Get ProductId and Purchase Qty List)
        public static List<Stock_Transaction> Purchase_Balance(int _year, int _month, List<long> productIdList)
        {
            POSEntities entity = new POSEntities();
            List<Stock_Transaction> _purchaseResult = new List<Stock_Transaction>();
            var _purchaseList = (from p in entity.PurchaseDetails
                                 join pd in entity.Products on p.ProductId equals pd.Id
                                 join mp in entity.MainPurchases on p.MainPurchaseId equals mp.Id
                                 where p.IsDeleted == false && mp.IsPurchase==true
                                 && productIdList.Contains(pd.Id)
                                    && mp.Date.Value.Month == _month && mp.Date.Value.Year == _year
                                 select new Stock_Transaction
                                 {
                                     ProductId = p.ProductId,
                                     Purchase = p.Qty
                                 }
                                 ).ToList();

            if (_purchaseList.Count > 0)
            {

                _purchaseResult = _purchaseList.GroupBy(x => new { x.ProductId })
                                  .Select(y => new Stock_Transaction()
                                  {


                                      ProductId = y.Key.ProductId,
                                      Purchase = y.Sum(x => x.Purchase)

                                  }).ToList();

            }
            return _purchaseResult;

        }

        //Consignment (Get ProductId and Purchase Consignment Qty List)
        public static List<Stock_Transaction> Consignment_Balance(int _year, int _month, List<long> productIdList)
        {
            POSEntities entity = new POSEntities();
            List<Stock_Transaction> _consignmentResult = new List<Stock_Transaction>();
            var _consignmentList = (from p in entity.ProductQuantityChanges
                                    join pd in entity.Products on p.ProductId equals pd.Id
                                    where
                                      productIdList.Contains(pd.Id)
                                      && p.UpdateDate.Value.Month == _month && p.UpdateDate.Value.Year == _year
                                    select new Stock_Transaction
                                 {
                                     ProductId = p.ProductId,
                                     Consignment = p.StockInQty
                                 }
                                   ).ToList();

            if (_consignmentList.Count > 0)
            {
                _consignmentResult = _consignmentList.GroupBy(x => new { x.ProductId })
                                   .Select(y => new Stock_Transaction()
                                   {


                                       ProductId = y.Key.ProductId,
                                       Consignment = y.Sum(x => x.Consignment)

                                   }).ToList();

            }
            return _consignmentResult;

        }

        //Refund (Get ProductId and Refund Qty List)
        public static List<Stock_Transaction> Refund_Balance(int _year, int _month, List<long> productIdList)
        {
            POSEntities entity = new POSEntities();
            List<string> type = new List<string> { "Refund", "CreditRefund" };
            List<Stock_Transaction> _refundResult = new List<Stock_Transaction>();
            var _refundList = (from td in entity.TransactionDetails
                               join pd in entity.Products on td.ProductId equals pd.Id
                               join t in entity.Transactions on td.TransactionId equals t.Id
                               where t.IsDeleted == false
                               && type.Contains(t.Type)
                               && productIdList.Contains(pd.Id)
                                 && t.DateTime.Value.Month == _month && t.DateTime.Value.Year == _year
                               select new Stock_Transaction
                               {
                                   ProductId = td.ProductId,
                                   Refund = td.Qty
                               }
                                   ).ToList();

            if (_refundList.Count > 0)
            {
                _refundResult = _refundList.GroupBy(x => new { x.ProductId })
                                .Select(y => new Stock_Transaction()
                                {


                                    ProductId = y.Key.ProductId,
                                    Refund = y.Sum(x => x.Refund)

                                }).ToList();


            }
            return _refundResult;
        }

        //Sale (Get ProductId and Sale Qty List)
        public static List<Stock_Transaction> Sale_Balance(int _year, int _month, List<long> productIdList)
        {
            POSEntities entity = new POSEntities();
            List<string> _type = new List<string> { "Sale", "Credit" };
            List<Stock_Transaction> _saleResult = new List<Stock_Transaction>();
            var _saleList = (from tds in entity.TransactionDetails
                             join pd in entity.Products on tds.ProductId equals pd.Id
                             join t in entity.Transactions on tds.TransactionId equals t.Id
                             where tds.IsDeleted == false
                             && t.IsComplete==true
                               && productIdList.Contains(pd.Id)
                             && _type.Contains(t.Type)
                                && t.DateTime.Value.Month == _month && t.DateTime.Value.Year == _year
                                && t.DateTime.Value.Month == _month && t.DateTime.Value.Year == _year
                             select new Stock_Transaction
                             {
                                 ProductId = tds.ProductId,
                                 Sale = tds.Qty
                             }
                                   ).ToList();

            if (_saleList.Count > 0)
            {
                _saleResult = _saleList.GroupBy(x => new { x.ProductId })
                                .Select(y => new Stock_Transaction()
                                {


                                    ProductId = y.Key.ProductId,
                                    Sale = y.Sum(x => x.Sale)

                                }).ToList();

            }
            return _saleResult;
        }


        #region Adjustment (Get ProductId and Adjustment Qty List)
        //public static List<Stock_Transaction> Adjustment_Balance(int _year, int _month, List<long> productIdList)
        //{
        //    POSEntities entity = new POSEntities();
        //    List<string> _type = new List<string> { "Sale", "Credit" };
        //    List<Stock_Transaction> _AdjustmentResult = new List<Stock_Transaction>();
        //    var _AdjustmentList = (from d in entity.Adjustments
        //                       join pd in entity.Products on d.ProductId equals pd.Id
        //                       where d.IsDeleted == false
        //                         && productIdList.Contains(pd.Id)
        //                        && d.AdjustmentDateTime.Value.Month == _month && d.AdjustmentDateTime.Value.Year == _year
        //                       select new Stock_Transaction
        //                       {
        //                           ProductId = d.ProductId,
        //                           Adjustment = d.AdjustmentQty
        //                       }
        //                           ).ToList();

        //    if (_AdjustmentList.Count > 0)
        //    {
        //        _AdjustmentResult = _AdjustmentList.GroupBy(x => new { x.ProductId })
        //                          .Select(y => new Stock_Transaction()
        //                          {


        //                              ProductId = y.Key.ProductId,
        //                              Adjustment = y.Sum(x => x.Adjustment)

        //                          }).ToList();

        //    }
        //    return _AdjustmentResult;
        //}
#endregion

        #region Adjustment (Get ProductId and Adjustment Qty List)
        public static List<Stock_Transaction> Adjustment_Balance(int _year, int _month, List<long> productIdList)
        {
            POSEntities entity = new POSEntities();
            List<string> _type = new List<string> { "Sale", "Credit" };
            List<Stock_Transaction> _adjustmentResult = new List<Stock_Transaction>();
            var _adjustmentList = (from d in entity.Adjustments
                               join pd in entity.Products on d.ProductId equals pd.Id
                               where d.IsDeleted == false
                                 && productIdList.Contains(pd.Id)
                                && d.AdjustmentDateTime.Value.Month == _month && d.AdjustmentDateTime.Value.Year == _year
                               select new Stock_Transaction
                               {
                                   ProductId = d.ProductId,
                                   AdjustmentQty= d.AdjustmentQty
                               }
                                   ).ToList();

            if (_adjustmentList.Count > 0)
            {
                _adjustmentResult = _adjustmentList.GroupBy(x => new { x.ProductId })
                                  .Select(y => new Stock_Transaction()
                                  {


                                      ProductId = y.Key.ProductId,
                                      AdjustmentQty = y.Sum(x => x.AdjustmentQty)

                                  }).ToList();

            }
            return _adjustmentResult;
        }
        #endregion


        #region Stock Transaction for Backend run process

        //Opening_Balance
        public static int Opening_Run_Balance(int _year, int _month, long productId)
        {
            POSEntities entity = new POSEntities();
            int _openingBalance = 0;

            int _preMonth = _month - 1;

            string tranDate = Month_Name(_preMonth, _year);

            var stockTranList = (from o in entity.StockTransactions where o.ProductId == productId && ((o.Year < _year && o.Year <= _year) || (o.Year == _year) && (o.Year <= _year && o.Month < _month)) select o).OrderBy(x => x.Year).OrderByDescending(x => x.Month).FirstOrDefault();


            if (stockTranList != null)
            {

                _openingBalance = Convert.ToInt32(stockTranList.Opening + (stockTranList.Purchase + stockTranList.Refund + stockTranList.Consignment + stockTranList.AdjustmentStockIn + stockTranList.ConversionStockIn) - (stockTranList.Sale + stockTranList.AdjustmentStockOut + stockTranList.ConversionStockOut));
            }

            return _openingBalance;
        }

        //update Opening Blance if delete in transaction process
        public static void Update_Opening_BalanceFor_NextMonth(int _month, int _year, int _productId, int _Qty)
        {
            POSEntities entity = new POSEntities();


            if (_month == 12)
            {
                _year = _year + 1;
                _month = 1;
            }
            else
            {
                _month = _month + 1;
            }

            // string _tranDate = Month_Name(_month, _year);

            var _stockTranIDList = (from x in entity.StockTransactions
                                    where x.ProductId == _productId
                                        && x.Year >= _year && x.Month >= _month
                                    select x.StockTranId).ToList();

            if (_stockTranIDList.Count > 0)
            {
                foreach (var stocktranId in _stockTranIDList)
                {
                    APP_Data.StockTransaction updateStockTransaction = (from s in entity.StockTransactions where s.StockTranId == stocktranId select s).FirstOrDefault();
                    updateStockTransaction.Opening = updateStockTransaction.Opening + _Qty;
                    entity.Entry(updateStockTransaction).State = EntityState.Modified;
                    entity.SaveChanges();
                }
            }



        }

        //Purchase Process
        public static void Purchase_Run_Process(int _year, int _month, List<Stock_Transaction> productList)
        {
            POSEntities entity = new POSEntities();

            //Purchase Save or Update
            foreach (var pro in productList)
            {
                string _tranDate = Month_Name(_month, _year);
                var _stockTranID = (from x in entity.StockTransactions
                                    where x.ProductId == pro.ProductId
                                        && x.TranDate == _tranDate
                                    select x.StockTranId).FirstOrDefault();

                APP_Data.StockTransaction _stObject = new APP_Data.StockTransaction();
                if (_stockTranID == 0)
                {

                    _stObject.TranDate = _tranDate;
                    _stObject.ProductId = Convert.ToInt32(pro.ProductId);
                    _stObject.Opening = Opening_Run_Balance(_year, _month, Convert.ToInt64(pro.ProductId));
                    _stObject.Purchase = pro.Purchase;
                    _stObject.Refund = 0;
                    _stObject.Sale = 0;
                    _stObject.AdjustmentStockIn = 0;
                    _stObject.AdjustmentStockOut = 0;
                    _stObject.Consignment = 0;
                    _stObject.ConversionStockIn = 0;
                    _stObject.ConversionStockOut = 0;
                    _stObject.Month = _month;
                    _stObject.Year = _year;
                    entity.StockTransactions.Add(_stObject);
                    entity.SaveChanges();



                }
                else
                {

                    APP_Data.StockTransaction updateStockTransaction = (from s in entity.StockTransactions where s.StockTranId == _stockTranID select s).FirstOrDefault();
                    updateStockTransaction.Purchase = updateStockTransaction.Purchase + pro.Purchase;
                    //if (updateStockTransaction.Opening > 0)
                    //{
                    //    updateStockTransaction.Opening = Opening_Run_Balance(_year, _month, Convert.ToInt64(pro.ProductId)) + pro.Purchase;
                    //}

                    entity.Entry(updateStockTransaction).State = EntityState.Modified;
                    entity.SaveChanges();

                }

                Update_Opening_BalanceFor_NextMonth(_month, _year, Convert.ToInt32(pro.ProductId), Convert.ToInt32(pro.Purchase));
            }

        }


        //Consignment Process
        public static void Consignment_Run_Process(int _year, int _month, List<Stock_Transaction> productList)
        {
            POSEntities entity = new POSEntities();

            //Purchase Save or Update
            foreach (var pro in productList)
            {
                string _tranDate = Month_Name(_month, _year);
                var _stockTranID = (from x in entity.StockTransactions
                                    where x.ProductId == pro.ProductId
                                        && x.TranDate == _tranDate
                                    select x.StockTranId).FirstOrDefault();

                APP_Data.StockTransaction _stObject = new APP_Data.StockTransaction();
                if (_stockTranID == 0)
                {

                    _stObject.TranDate = _tranDate;
                    _stObject.ProductId = Convert.ToInt32(pro.ProductId);
                    _stObject.Opening = Opening_Run_Balance(_year, _month, Convert.ToInt64(pro.ProductId));
                    _stObject.Purchase = 0;
                    _stObject.Refund = 0;
                    _stObject.Sale = 0;
                    _stObject.AdjustmentStockIn = 0;
                    _stObject.AdjustmentStockOut = 0;
                    _stObject.Month = _month;
                    _stObject.Year = _year;
                    _stObject.Consignment = Convert.ToInt32(pro.Consignment);
                    _stObject.ConversionStockIn = 0;
                    _stObject.ConversionStockOut = 0;
                    entity.StockTransactions.Add(_stObject);
                    entity.SaveChanges();
                }
                else
                {

                    APP_Data.StockTransaction updateStockTransaction = (from s in entity.StockTransactions where s.StockTranId == _stockTranID select s).FirstOrDefault();

                    updateStockTransaction.Consignment = updateStockTransaction.Consignment + Convert.ToInt32(pro.Consignment);
                    //if (updateStockTransaction.Opening > 0)
                    //{
                    //    updateStockTransaction.Opening = Opening_Run_Balance(_year, _month, Convert.ToInt64(pro.ProductId)) + Convert.ToInt32(pro.Consignment);
                    //}
                    entity.Entry(updateStockTransaction).State = EntityState.Modified;
                    entity.SaveChanges();
                }
                Update_Opening_BalanceFor_NextMonth(_month, _year, Convert.ToInt32(pro.ProductId), Convert.ToInt32(pro.Consignment));
            }

        }


        //Refund Process
        public static void Refund_Run_Process(int _year, int _month, List<Stock_Transaction> productList)
        {
            POSEntities entity = new POSEntities();

            //Purchase Save or Update
            foreach (var pro in productList)
            {
                string _tranDate = Month_Name(_month, _year);
                var _stockTranID = (from x in entity.StockTransactions
                                    where x.ProductId == pro.ProductId
                                        && x.TranDate == _tranDate
                                    select x.StockTranId).FirstOrDefault();

                APP_Data.StockTransaction _stObject = new APP_Data.StockTransaction();
                if (_stockTranID == 0)
                {

                    _stObject.TranDate = _tranDate;
                    _stObject.ProductId = Convert.ToInt32(pro.ProductId);
                    _stObject.Opening = Opening_Run_Balance(_year, _month, Convert.ToInt64(pro.ProductId));
                    _stObject.Purchase = 0;
                    _stObject.Refund = pro.Refund;
                    _stObject.Sale = 0;
                    _stObject.AdjustmentStockIn = 0;
                    _stObject.AdjustmentStockOut = 0;
                    _stObject.Consignment = 0;
                    _stObject.ConversionStockIn = 0;
                    _stObject.ConversionStockOut = 0;
                    _stObject.Month = _month;
                    _stObject.Year = _year;
                    entity.StockTransactions.Add(_stObject);
                    entity.SaveChanges();
                }
                else
                {

                    APP_Data.StockTransaction updateStockTransaction = (from s in entity.StockTransactions where s.StockTranId == _stockTranID select s).FirstOrDefault();

                    updateStockTransaction.Refund = updateStockTransaction.Refund + pro.Refund;
                    //if (updateStockTransaction.Opening > 0)
                    //{
                    //    updateStockTransaction.Opening = Opening_Run_Balance(_year, _month, Convert.ToInt64(pro.ProductId)) + pro.Refund;
                    //}
                    entity.Entry(updateStockTransaction).State = EntityState.Modified;
                    entity.SaveChanges();
                }
                Update_Opening_BalanceFor_NextMonth(_month, _year, Convert.ToInt32(pro.ProductId), Convert.ToInt32(pro.Refund));
            }

        }

        //Sale Process
        public static void Sale_Run_Process(int _year, int _month, List<Stock_Transaction> productList)
        {
            POSEntities entity = new POSEntities();

            //Purchase Save or Update
            foreach (var pro in productList)
            {
                string _tranDate = Month_Name(_month, _year);
                var _stockTranID = (from x in entity.StockTransactions
                                    where x.ProductId == pro.ProductId
                                        && x.TranDate == _tranDate
                                    select x.StockTranId).FirstOrDefault();

                APP_Data.StockTransaction _stObject = new APP_Data.StockTransaction();
                if (_stockTranID == 0)
                {

                    _stObject.TranDate = _tranDate;
                    _stObject.ProductId = Convert.ToInt32(pro.ProductId);
                    _stObject.Opening = Opening_Run_Balance(_year, _month, Convert.ToInt64(pro.ProductId));
                    _stObject.Purchase = 0;
                    _stObject.Refund = 0;
                    _stObject.Sale = pro.Sale;
                    _stObject.AdjustmentStockIn = 0;
                    _stObject.AdjustmentStockOut = 0;
                    _stObject.Consignment = 0;
                    _stObject.ConversionStockIn = 0;
                    _stObject.ConversionStockOut = 0;
                    _stObject.Month = _month;
                    _stObject.Year = _year;
                    entity.StockTransactions.Add(_stObject);
                    entity.SaveChanges();
                }
                else
                {

                    APP_Data.StockTransaction updateStockTransaction = (from s in entity.StockTransactions where s.StockTranId == _stockTranID select s).FirstOrDefault();
                    updateStockTransaction.Sale = updateStockTransaction.Sale + pro.Sale;
                    //if (updateStockTransaction.Opening > 0)
                    //{
                    //    updateStockTransaction.Opening = Opening_Run_Balance(_year, _month, Convert.ToInt64(pro.ProductId)) + pro.Sale;
                    //}
                    entity.Entry(updateStockTransaction).State = EntityState.Modified;
                    entity.SaveChanges();
                }
                Update_Opening_BalanceFor_NextMonth(_month, _year, Convert.ToInt32(pro.ProductId), Convert.ToInt32(pro.Sale * -1));
            }

        }

        #region Adjustment Process
        public static void Adjustment_Run_Process(int _year, int _month, List<Stock_Transaction> productList, bool IsDelete=false)
        {
            POSEntities entity = new POSEntities();

            //Purchase Save or Update
            foreach (var pro in productList)
            {
                string _tranDate = Month_Name(_month, _year);
                var _stockTranID = (from x in entity.StockTransactions
                                    where x.ProductId == pro.ProductId
                                        && x.TranDate == _tranDate
                                    select x.StockTranId).FirstOrDefault();

                APP_Data.StockTransaction _stObject = new APP_Data.StockTransaction();
                if (_stockTranID == 0)
                {

                    _stObject.TranDate = _tranDate;
                    _stObject.ProductId = Convert.ToInt32(pro.ProductId);
                    _stObject.Opening = Opening_Run_Balance(_year, _month, Convert.ToInt64(pro.ProductId));
                    _stObject.Purchase = 0;
                    _stObject.Refund = 0;
                    _stObject.Sale = 0;
                    if (pro.AdjustmentQty < 0)
                    {
                        _stObject.AdjustmentStockOut = pro.AdjustmentQty * -1 ;
                        _stObject.AdjustmentStockIn= 0;
                    }
                    else
                    {
                        _stObject.AdjustmentStockIn = pro.AdjustmentQty;
                        _stObject.AdjustmentStockOut = 0;
                    }
                    
                    _stObject.Consignment = 0;
                    _stObject.ConversionStockIn = 0;
                    _stObject.ConversionStockOut = 0;
                    _stObject.Month = _month;
                    _stObject.Year = _year;
                    entity.StockTransactions.Add(_stObject);
                    entity.SaveChanges();
                }
                else
                {

                    APP_Data.StockTransaction updateStockTransaction = (from s in entity.StockTransactions where s.StockTranId == _stockTranID select s).FirstOrDefault();

                    if (!IsDelete)
                    {
                        if (pro.AdjustmentQty < 0)
                        {
                            updateStockTransaction.AdjustmentStockOut = updateStockTransaction.AdjustmentStockOut + (pro.AdjustmentQty * -1);
                        }
                        else
                        {
                            updateStockTransaction.AdjustmentStockIn = updateStockTransaction.AdjustmentStockIn + pro.AdjustmentQty;
                        }
                    }
                    else
                    {
                        if (pro.AdjustmentQty < 0)
                        {
                            updateStockTransaction.AdjustmentStockOut = updateStockTransaction.AdjustmentStockOut - (pro.AdjustmentQty  * -1);
                        }
                        else
                        {
                            updateStockTransaction.AdjustmentStockIn = updateStockTransaction.AdjustmentStockIn - pro.AdjustmentQty;
                        }
                    }
                    
                    //if (updateStockTransaction.Opening > 0)
                    //{
                    //    updateStockTransaction.Opening = Opening_Run_Balance(_year, _month, Convert.ToInt64(pro.ProductId)) + pro.Adjustment;
                    //}
                    entity.Entry(updateStockTransaction).State = EntityState.Modified;
                    entity.SaveChanges();
                }
                Update_Opening_BalanceFor_NextMonth(_month, _year, Convert.ToInt32(pro.ProductId), Convert.ToInt32(pro.AdjustmentQty * -1));
            }

        }
        #endregion

        #region Conversion Process
        public static void Conversion_Run_Process(int _year, int _month, List<Stock_Transaction> productList,bool IsStockIn)
        {
            POSEntities entity = new POSEntities();

            //Purchase Save or Update
            foreach (var pro in productList)
            {
                string _tranDate = Month_Name(_month, _year);
                var _stockTranID = (from x in entity.StockTransactions
                                    where x.ProductId == pro.ProductId
                                        && x.TranDate == _tranDate
                                    select x.StockTranId).FirstOrDefault();

                APP_Data.StockTransaction _stObject = new APP_Data.StockTransaction();
                if (_stockTranID == 0)
                {

                    _stObject.TranDate = _tranDate;
                    _stObject.ProductId = Convert.ToInt32(pro.ProductId);
                    _stObject.Opening = Opening_Run_Balance(_year, _month, Convert.ToInt64(pro.ProductId));
                    _stObject.Purchase = 0;
                    _stObject.Refund = 0;
                    _stObject.Sale =0;
                    _stObject.AdjustmentStockIn = 0;
                    _stObject.AdjustmentStockOut = 0;
                    _stObject.Consignment = 0;
                    _stObject.ConversionStockIn = IsStockIn == true ? pro.ConversionStockIn : 0;
                    _stObject.ConversionStockOut = IsStockIn == true ? 0 : pro.ConversionStockOut;
                    _stObject.Month = _month;
                    _stObject.Year = _year;
                    entity.StockTransactions.Add(_stObject);
                    entity.SaveChanges();
                }
                else
                {

                    APP_Data.StockTransaction updateStockTransaction = (from s in entity.StockTransactions where s.StockTranId == _stockTranID select s).FirstOrDefault();
                    //updateStockTransaction.ConversionStockIn = updateStockTransaction.Sale + pro.Sale;
                    updateStockTransaction.ConversionStockIn = IsStockIn == true ? updateStockTransaction.ConversionStockIn + pro.ConversionStockIn : updateStockTransaction.ConversionStockIn;
                    updateStockTransaction.ConversionStockOut = IsStockIn == true ? updateStockTransaction.ConversionStockOut : updateStockTransaction.ConversionStockOut + pro.ConversionStockOut;
                    //if (updateStockTransaction.Opening > 0)
                    //{
                    //    updateStockTransaction.Opening = Opening_Run_Balance(_year, _month, Convert.ToInt64(pro.ProductId)) + pro.Sale;
                    //}
                    entity.Entry(updateStockTransaction).State = EntityState.Modified;
                    entity.SaveChanges();
                }
                Update_Opening_BalanceFor_NextMonth(_month, _year, Convert.ToInt32(pro.ProductId), IsStockIn == true ? Convert.ToInt32(pro.ConversionStockIn * -1) : Convert.ToInt32(pro.ConversionStockOut * -1));
            }

        }
        #endregion

        #endregion
        #endregion

        #region Convert String To Date Time
        public static DateTime Convert_Date(string date)
        {
            // string date = dgvTransactionList.Rows[e.RowIndex].Cells[2].Value.ToString();
            DateTime _Trandate = DateTime.ParseExact(date, "dd-MM-yyyy", null);
            return _Trandate;
        }

        #endregion

        #region  Remove Comma
   
        public static string[] Remove_Comma(string _dataList)
        {
            string[] _removeCommaDataList = _dataList.Split(',');
            return _removeCommaDataList;
        }
        #endregion

        #region Convert string[] To Long[]
        public static List<long> Convert_String_To_Long(string[] _dataList)
        {
            List<long> _longDataList = _dataList.Select(long.Parse).ToList();
            return _longDataList;
        }
        #endregion

        #region Get Whole Sale Or Retial Sale
        public static int WholeSalePriceOrSellingPrice(Product pro, bool IsWholeSale)
        {
            int price = 0;
            if (IsWholeSale)
            {
                price = Convert.ToInt32(pro.WholeSalePrice);
            }
            else
            {
                price = Convert.ToInt32(pro.Price);
            }
            return price;
        }
        #endregion

        #region Get Report Path
        public static string GetReportPath(string paymentType)
        {
            string reportPath = "";
            string printer = SettingController.SelectDefaultPrinter;
            switch (printer)
            {
                case "A4 Printer":
                    switch (paymentType)
                    {
                        case "Cash":
                            reportPath = "\\Reports\\InvoiceCashA4.rdlc";
                            break;
                        case "Credit":
                            reportPath = "\\Reports\\InvoiceCreditA4.rdlc";
                            break;
                        case "MPU":
                            reportPath = "\\Reports\\InvoiceMPUA4.rdlc";
                            break;
                        case "GiftCard":
                            reportPath = "\\Reports\\InvoiceGiftcardA4.rdlc";
                            break;
                        case "FOC":
                            reportPath = "\\Reports\\InvoiceFOCA4.rdlc";
                            break;
                        case "Tester":
                            reportPath = "\\Reports\\InvoiceFOCA4.rdlc";
                            break;
                        case "Settlement":
                            reportPath = "\\Reports\\InvoiceSettlementA4.rdlc";
                            break;
                    }
                    break;
                case "Slip Printer":
                    switch (paymentType)
                    {
                        case "Cash":
                            reportPath = "\\Reports\\InvoiceCash.rdlc";
                            break;
                        case "Credit":
                            reportPath = "\\Reports\\InvoiceCredit.rdlc";
                            break;
                        case "MPU":
                            reportPath = "\\Reports\\InvoiceMPU.rdlc";
                            break;
                        case "GiftCard":
                            reportPath = "\\Reports\\InvoiceGiftcard.rdlc";
                            break;
                        case "FOC":
                            reportPath = "\\Reports\\InvoiceFOC.rdlc";
                            break;
                        case "Tester":
                            reportPath = "\\Reports\\InvoiceFOC.rdlc";
                            break;
                        case "Settlement":
                            reportPath = "\\Reports\\InvoiceSettlement.rdlc";
                            break;
                    }
                    break;
            }
            return reportPath;
        }
        #endregion

        #region  Get A4 Print or Slip Print
        public static string GetDefaultPrinter()
        {
            string printer = SettingController.SelectDefaultPrinter;
            return printer;
        }
        #endregion

        #region Slip Logo
        public static void Slip_Log(ReportViewer rv)
        {
          
         //   ReportParameter ImagePath = new ReportParameter("ImagePath", "file:\\" + Application.StartupPath + "\\img\\logo_frenzo.png");
            if(!Get_Image(rv))
            {
                MessageBox.Show("Please define Logo in Configuration Setting!", "mPOS");
                Setting form = new Setting();
                form.ShowDialog();
                Get_Image(rv);
            }

        }

        private static bool Get_Image(ReportViewer rv)
        {
            if (SettingController.Logo != "")
            {
                string imagePath = SettingController.Logo.Substring(7);
                Image_Parameter(rv, imagePath);
                return true;
            }
            else
                return false;
        }

        private static void Image_Parameter(ReportViewer rv, string imagePath)
        {
            rv.LocalReport.EnableExternalImages = true;
            ReportParameter ImagePath = new ReportParameter("ImagePath", "file:\\" + Application.StartupPath + "\\logo\\" + imagePath);
            rv.LocalReport.SetParameters(ImagePath);
        }
        #endregion

        #region Slip Footer
        public static void Slip_A4_Footer(ReportViewer rv)
        {
            rv.LocalReport.EnableExternalImages = true;
           
            ReportParameter Footer = new ReportParameter("Footer", SettingController.FooterPage);
            rv.LocalReport.SetParameters(Footer);
        }
        #endregion

        #region Product AutoGenerateNo
        public static string Stock_AutoGenerateNo(int brandId)
        {
            string _registerNo = "020";
            string _autoGenerateNo=Get_BrandAutoNo_IncrementNo(brandId);

            string _stockAutoGenerateNo = _registerNo + _autoGenerateNo;
            return _stockAutoGenerateNo;
            
        }

        public static string Get_BrandAutoNo_IncrementNo(int brandId)
        {
            string _stockGenerateNo="";
            POSEntities entity = new POSEntities();

            var _brandData = (from b in entity.Brands where b.Id == brandId select b).FirstOrDefault();
            string _brandId=_brandData.Id.ToString();
            int _incrementNo = 0;
            if ((_brandData.AutoGenerateNo.ToString()).Length >= 5)
            {
                _incrementNo = Convert.ToInt32(_brandData.AutoGenerateNo);
            }
            else
            {
                 _incrementNo = Convert.ToInt32(_brandData.AutoGenerateNo) + 1;
            }


            
              string incrementNo = _incrementNo.ToString();
            string _brandAutoNo = "";
            switch (_brandId.Length)
            {
                case 1:
                    _brandAutoNo = _brandId + "0000";
                    break;
                case 2:
                    _brandAutoNo = _brandId + "000";
                    break;
                case 3:
                    _brandAutoNo = _brandId + "00";
                    break;
                case 4:
                    _brandAutoNo = _brandId + "0";
                    break;
                case 5:
                    _brandAutoNo = _brandId;
                    break;
            }


            string _autoGenerateNo = "";
            switch (incrementNo.Length)
            {
                case 1:
                    _autoGenerateNo = "0000" + incrementNo;
                    break;
                case 2:
                    _autoGenerateNo = "000" + incrementNo;
                    break;
                case 3:
                    _autoGenerateNo = "00" + incrementNo;
                    break;
                case 4:
                    _autoGenerateNo = "0" + incrementNo;
                    break;
                case 5:
                    _autoGenerateNo =  incrementNo;
                    break;
            }

            _stockGenerateNo = _brandAutoNo + _autoGenerateNo;

            return _stockGenerateNo; 
        }
        #endregion

        #region Printing
        public static void Get_Print(ReportViewer rv)
        {
            int copy = Convert.ToInt32(SettingController.DefaultNoOfCopies);
            for (int i = 0; i < copy; i++)
            {
                PrintDoc.PrintReport(rv, GetDefaultPrinter());
            }
        }
        #endregion

        #region Get Room No
        public static string GetRoomNo(int? roomId)
        {
              string roomNo ="";
              if (roomId != null)
              {
                  POSEntities entity = new POSEntities();
                  roomNo = (from r in entity.Rooms where r.Id == roomId select r.RoomNo).FirstOrDefault();
              }
              else
              {
                  roomNo = "-";
              }
            return roomNo;
        }
        #endregion

        #region return plus prepaid amount in credit transaction
        public static void Plus_PreaidAmt(Transaction ts)
        {
            POSEntities entity = new POSEntities();
            // update Prepaid Transaction id = false   and delete list in useprepaiddebt table
            var prepaidList = entity.UsePrePaidDebts.Where(x => x.CreditTransactionId == ts.Id && ts.IsActive == true).ToList();

            if (prepaidList.Count > 0)
            {
                List<string> prepaidIdList = prepaidList.Select(x => x.PrePaidDebtTransactionId).ToList();

                (from t in entity.Transactions where prepaidIdList.Contains(t.Id) select t).ToList().ForEach(t => t.IsActive = false);

                //var setToRemove = new HashSet<UsePrePaidDebt>(prepaidList);
                // prepaidList.RemoveAll(x => setToRemove.Contains(x));
                //entity.UsePrePaidDebts.Where(x => x.CreditTransactionId == ts.Id).ToList().RemoveAll(x => setToRemove.Contains(x));
                //entity.SaveChanges();

                foreach (var p in prepaidList)
                {
                    APP_Data.UsePrePaidDebt DeleteObj = (from u in entity.UsePrePaidDebts where u.Id == p.Id select u).FirstOrDefault();
                    entity.UsePrePaidDebts.Remove(DeleteObj);
                    entity.SaveChanges();
                }
            }
        }
        #endregion


        #region Check and Add FOC in Category
        public static void Check_AddFOCInCag()
        {
            POSEntities entity = new POSEntities();
            var val = (from c in entity.ProductCategories where c.Name == "FOC" select c).FirstOrDefault();

            if (val == null)
            {
                APP_Data.ProductCategory cag = new APP_Data.ProductCategory();

                cag.Name = "FOC";
                entity.ProductCategories.Add(cag);
                entity.SaveChanges();

                APP_Data.ProductSubCategory subCag = new APP_Data.ProductSubCategory();
                subCag.Name = "FOC";
                subCag.ProductCategoryId = cag.Id;
                entity.ProductSubCategories.Add(subCag);
                entity.SaveChanges();

            }
        }
        #endregion
    }

    public class Convert_Controller
    {
        public int PurchaseDetailId;
        public int ConvertQty;
    }

    public class Damage_Controller
    {
        public int Id;
        public string ProductName;
        public string ProductCode;
        public DateTime? AdjustmentDateTime;
        public int? DamageQty;
        public long Price;
        public long? TotalCost;
        public string Reason;
        public string ResponsibleName;

    }

    public class Adjustment_Controller
    {
       // public int Id;
        public string ProductName;
        public string ProductCode;
        public DateTime? AdjustmentDateTime;
        public int? StockIn;
        public int? StockOut;
        public long Price;
        public long? TotalCost;
        public string Reason;
        public string ResponsibleName;

    }

    public class Stock_Transaction
    {

        public long? ProductId;
        public string TranDate;
        public int? Opening;
        public int? Purchase;
        public int? Refund;
        public int? Sale;
       // public int? Adjustment;
        public long? Consignment;

        public string ProductName;
        public string ProductCode;
        public int? AdjustmentStockIn;
        public int? AdjustmentStockOut;
        public int? ConversionStockIn;
        public int? ConversionStockOut;

        public int? AdjustmentQty;

    }

    public static class MemberShip
    {
        public static string UserName;
        public static string UserRole;
        public static int UserRoleId;
        public static int UserId;
        public static bool isLogin;
        public static bool isAdmin;
        public static int CounterId;
    }

    public static class TransactionType
    {
        public static string Sale
        {
            get { return "Sale"; }
        }
        public static string Refund
        {
            get { return "Refund"; }
        }
        public static string Settlement
        {
            get { return "Settlement"; }
        }
        public static string Credit
        {
            get { return "Credit"; }
        }
        public static string CreditRefund
        {
            get { return "CreditRefund"; }
        }
        public static string Prepaid
        {
            get { return "Prepaid"; }
        }
    }

    public class TransactionDetailByItemHolder
    {
        //   public int ItemId;
        //public string ProductSku;
        public string ItemNo;
        public string Name;
        public string TransactionId;
        public string TransactionType;
        public int Qty;
        public int TotalAmount;
        //public DateTime date;
        public DateTime TransactionDate;
        public string Counter_Name;
    }

    public class TopProductHolder
    {
        public string ProductId;
        public string Name;
        public decimal Discount;
        public int Qty;
        public long UnitPrice;
        public long totalAmount;

    }
    public class CustomerInfoHolder
    {
        public int PayableAmount;
        public int Id;
        public string Name;
        public string PhNo;
        public string Address;
        public long OutstandingAmount;
        public long RefundAmount;
    }


    public class ConsignmentController
    {
        public int ProductId;
        public string Name;
        public int Qty;
        public int Price;
        public long Total;
        public int ConsignmentPrice;
        public long TotalConsignmentPrice;
        public string counter;
        public int Profit;
        public long TotalProfit;
        public int TransactionDetailId;

    }
    public class ReportItemSummary
    {
        public string Id;
        public string Name;
        public int Qty;
        public int UnitPrice;
        public long totalAmount;
        public int PaymentId;
        public string Size;
        public Boolean IsFOC;
        public int SellingPrice;
        public string Remark;
    }
    public class ProductReportController
    {
        public int Id;
        public int Qty;
        public string SKUCode;
        public string ProductName;
        public string BrandName;
        public int TotalQty;
        public string Segment;
        public string SubSegment;
        public string Line;
        public bool IsDiscontinous;
        public bool isConsignment;
        public int UnitPrice;
        public int TotalPrice;
        public int SubTotalPrice;
        public int? PurchasePrice;
        public string PhotoPath;


    }

    public class CustomerSaleController
    {
        public string CustomerName;
        public string ProductName;
        public int Price;
        public int Qty;
        public int TotalAmount;
        public int MemberDiscount;
        public decimal? MCDiscount;
        public int SubTotal;
        public string TransactionId;
        public string MemberType;
        public DateTime SaleDate;
        public string Remark;
    }
    public class SaleBreakDownController
    {
        public int bId;
        public string Name;
        public decimal Sales;
        public decimal BreakDown;
        public int saleQty;
        public decimal Refund;
        public int refundQty;
    }
    public class SpecialPromotionController
    {
        public int bId;
        public string Name;
        public decimal Sales;
        public decimal BreakDown;
        public int saleQty;
        public decimal Refund;
        public int refundQty;
    }

    public class PurchaseReportController
    {
        public DateTime Date;
        public string ProductName;
        public string SupplierName;
        public int UnitPrice;
        public int Qty;
        public Int64 TotalAmount;
        public string VourcherNo;

    }

    public class TotalDailyReport
    {
        public DateTime Date;
        public int TotalTransaction;
        public int TotalQty;
        public Int64 TotalCashAmount;
        public Int64 TotalCreditAmount;
        public Int64 TotalMPUAmount;
        public Int64 TotalGiftCardAmount;
        public Int64 TotalFOCAmount;
        public Int64 TotalTesterAmount;
        public Int64 TotalRefundAmount;
        public Int64 TotalRefundQty;
        public Int64 RepaidAmount;
    }

    public class ProfitAndLoss
    {
        public DateTime SaleDate;
        public int TotalSaleQty;
        public Int64 TotalPurchaseAmount;
        public Int64 TotalSaleAmount;
        public Int64 TotalDiscountAmount;
        public Int64 TotalTaxAmount;
        public Int64 ProfitAndLossAmount;
    }

    public class PurchaseProductController
    {

        public int PurchaseDetailId;
        public string Barcode;
        public string ProductName;
        public int Qty;
        public Int64 PurchasePrice;
        public Int64 Total;
        public Int64 ProductId;
        public int Id;
    }

    public class PurchaseDiscountController
    {
        public DateTime PurchaseDate;
        public string VoucherNo;
        public string SupplierName;
        public Int64 TotalAmount;
        public int DiscountAmount;
    }


    public class SaleProductController
    {

        public int PurchaseDetailId;
        public string Barcode;
        public string ProductName;
        public int Qty;
        public Int64 UnitPrice;
        public Int64 ConsignmentPrice;
        public Int64 ProductId;
        public int DiscountPercent;
        public int Tax;
        public bool IsFOC;
    }


    public class AverageMonthlySaleController
    {
        public string ProductCode;
        public string ProductName;
        public string Unit;
        public int JanQty;
        public int FebQty;
        public int MarQty;
        public int AprQty;
        public int MayQty;
        public int JunQty;
        public int JulQty;
        public int AugQty;
        public int SepQty;
        public int OctQty;
        public int NovQty;
        public int DecQty;
        public int TotalQty;
        public decimal AvgQty;
        public int SellingPrice;
        public Int64 TotalAmount;
        public string Remark;
    }


    public class RoleManagementController
    {
        public RoleManagementModel Setting { get; set; }
        public RoleManagementModel Consignor { get; set; }
        public RoleManagementModel MeasurementUnit { get; set; }
        public RoleManagementModel CurrencyExchange { get; set; }
        public RoleManagementModel TaxRate { get; set; }
        public RoleManagementModel City { get; set; }
        public RoleManagementModel Product { get; set; }
        public RoleManagementModel Brand { get; set; }
        public RoleManagementModel GiftCard { get; set; }
        public RoleManagementModel Customer { get; set; }
        public RoleManagementModel OutstandingCustomer { get; set; }
        public RoleManagementModel Supplier { get; set; }
        public RoleManagementModel OutstandingSupplier { get; set; }
        public RoleManagementModel ConsigmentSettlement { get; set; }
        public RoleManagementModel Category { get; set; }
        public RoleManagementModel SubCategory { get; set; }
        public RoleManagementModel Counter { get; set; }
        public RoleManagementModel PurchaseRole { get; set; }
        public RoleManagementModel MemberRule { get; set; }
        public RoleManagementModel Adjustment { get; set; }
        public RoleManagementModel Transaction { get; set; }
        public RoleManagementModel CreditTransaction { get; set; }
        public RoleManagementModel TransactionDetail { get; set; }
        public RoleManagementModel Refund { get; set; }
     //   public RoleManagementModel AdjustmentType { get; set; }
        public RoleManagementModel UnitConversion { get; set; }

        //Reports
        public RoleManagementModel TransactionReport { get; set; }
        public RoleManagementModel ItemSummaryReport { get; set; }
        public RoleManagementModel TaxSummaryReport { get; set; }
        public RoleManagementModel ReorderPointReport { get; set; }
        public RoleManagementModel TransactionDetailReport { get; set; }
        public RoleManagementModel OutstandingCustomerReport { get; set; }
        public RoleManagementModel TopBestSellerReport { get; set; }
        public RoleManagementModel TransactionSummaryReport { get; set; }

        public RoleManagementModel DailySaleSummary { get; set; }
        public RoleManagementModel DailyTotalTransactions { get; set; }
        public RoleManagementModel PurchaseReport { get; set; }
        public RoleManagementModel PurchaseDiscount { get; set; }
        public RoleManagementModel SaleBreakdown { get; set; }
        public RoleManagementModel CustomerSales { get; set; }
        public RoleManagementModel ProductReport { get; set; }
        public RoleManagementModel CustomerInformation { get; set; }
        public RoleManagementModel Consigment { get; set; }
        public RoleManagementModel ProfitAndLoss { get; set; }
        public RoleManagementModel AdjustmentReport { get; set; }
        public RoleManagementModel StockTransactionReport { get; set; }
        public RoleManagementModel AverageMonthlyReport { get; set; }

        private int UserRoleId { get; set; }

        public RoleManagementController()
        {
            Setting = new RoleManagementModel();
            Consignor = new RoleManagementModel();
            MeasurementUnit = new RoleManagementModel();
            CurrencyExchange = new RoleManagementModel();
            TaxRate = new RoleManagementModel();
            City = new RoleManagementModel();
            Product = new RoleManagementModel();
            Brand = new RoleManagementModel();
            GiftCard = new RoleManagementModel();
            Customer = new RoleManagementModel();
            OutstandingCustomer = new RoleManagementModel();
            Supplier = new RoleManagementModel();
            OutstandingSupplier = new RoleManagementModel();
            ConsigmentSettlement = new RoleManagementModel();
            Category = new RoleManagementModel();
            SubCategory = new RoleManagementModel();
            Counter = new RoleManagementModel();
            PurchaseRole = new RoleManagementModel();
            MemberRule = new RoleManagementModel();
            Adjustment = new RoleManagementModel();
            Transaction = new RoleManagementModel();
            CreditTransaction = new RoleManagementModel();
            TransactionDetail = new RoleManagementModel();
            Refund = new RoleManagementModel();
            UnitConversion = new RoleManagementModel();

            DailySaleSummary = new RoleManagementModel();
            TransactionReport = new RoleManagementModel();
            TransactionSummaryReport = new RoleManagementModel();
            TransactionDetailReport = new RoleManagementModel();
            DailyTotalTransactions = new RoleManagementModel();
            PurchaseReport = new RoleManagementModel();
            PurchaseDiscount = new RoleManagementModel();
            ItemSummaryReport = new RoleManagementModel();
            SaleBreakdown = new RoleManagementModel();
            TaxSummaryReport = new RoleManagementModel();
            TopBestSellerReport = new RoleManagementModel();
            CustomerSales = new RoleManagementModel();
            OutstandingCustomerReport = new RoleManagementModel();
            CustomerInformation = new RoleManagementModel();
            ProductReport = new RoleManagementModel();
            ReorderPointReport = new RoleManagementModel();
            Consigment = new RoleManagementModel();
            ProfitAndLoss = new RoleManagementModel();
            AdjustmentReport = new RoleManagementModel();
            StockTransactionReport = new RoleManagementModel();
            AverageMonthlyReport = new RoleManagementModel();
        }




        public void Load(int roleId)
        {
            UserRoleId = roleId;


            POSEntities entity = new POSEntities();
            //Setting
            Setting.Add = LoadRules(entity, "setting_define");

            //Consignor
            Consignor.EditOrDelete = LoadRules(entity, "consignor_edit");
            Consignor.Add = LoadRules(entity, "consignor_add");

            //Measurement Unit
            MeasurementUnit.EditOrDelete = LoadRules(entity, "measurementunit_edit");
            MeasurementUnit.Add = LoadRules(entity, "measurementunit_add");

            //Currency Exhcange
            CurrencyExchange.Add = LoadRules(entity, "currencyexchange_add");

            //Tax Rate
            TaxRate.EditOrDelete = LoadRules(entity, "taxrate_edit");
            TaxRate.Add = LoadRules(entity, "taxrate_add");

            //City
            City.EditOrDelete = LoadRules(entity, "city_edit");
            City.Add = LoadRules(entity, "city_add");

            //Product
            Product.View = LoadRules(entity, "product_view");
            Product.EditOrDelete = LoadRules(entity, "product_edit");
            Product.Add = LoadRules(entity, "product_add");
            //Brand
            Brand.View = LoadRules(entity, "brand_view");
            Brand.EditOrDelete = LoadRules(entity, "brand_edit");
            Brand.Add = LoadRules(entity, "brand_add");
            //GiftCard
            GiftCard.View = LoadRules(entity, "giftcard_view");
            GiftCard.Add = LoadRules(entity, "giftcard_add");
            GiftCard.EditOrDelete = LoadRules(entity, "giftcard_edit");
            //Customer
            Customer.View = LoadRules(entity, "customer_view");
            Customer.EditOrDelete = LoadRules(entity, "customer_edit");
            Customer.Add = LoadRules(entity, "customer_add");
            Customer.ViewDetail = LoadRules(entity, "customer_viewDetail");
            OutstandingCustomer.View = LoadRules(entity, "customer_viewDetail");
            OutstandingCustomer.View = LoadRules(entity,"outstandingcustomer_view");
            OutstandingCustomer.ViewDetail = LoadRules(entity, "outstandingcustomer_viewDetail");
            //Supplier
            Supplier.View = LoadRules(entity, "supplier_view");
            Supplier.EditOrDelete = LoadRules(entity, "supplier_edit");
            Supplier.Add = LoadRules(entity, "supplier_add");
            Supplier.ViewDetail = LoadRules(entity, "supplier_viewDetail");
            OutstandingSupplier.View = LoadRules(entity, "outstandingsupplier_view");
            OutstandingSupplier.ViewDetail = LoadRules(entity, "outstandingsupplier_viewDetail");
            //Consignment Settlement
            ConsigmentSettlement.View = LoadRules(entity, "consignmentsettlement_view");
            ConsigmentSettlement.EditOrDelete = LoadRules(entity, "consignmentsettlement_delete");
 
            //Category
            Category.View = LoadRules(entity, "category_view");
            Category.EditOrDelete = LoadRules(entity, "category_edit");
            Category.Add = LoadRules(entity, "category_add");
            //Sub Category
            SubCategory.View = LoadRules(entity, "subcategory_view");
            SubCategory.EditOrDelete = LoadRules(entity, "subcategory_edit");
            SubCategory.Add = LoadRules(entity, "subcategory_add");
            //Counter
            Counter.EditOrDelete = LoadRules(entity, "counter_edit");
            Counter.Add = LoadRules(entity, "counter_add");
            //Purchase
            PurchaseRole.EditOrDelete = LoadRules(entity, "purchase_delete");
            PurchaseRole.Add = LoadRules(entity, "purchase_add");
            PurchaseRole.ViewDetail = LoadRules(entity, "purchase_viewDetail");
            PurchaseRole.View = LoadRules(entity, "purchase_view");
            PurchaseRole.DeleteLog = LoadRules(entity, "purchase_deletelog");

            //Member Rule
            MemberRule.Add = LoadRules(entity, "memberrule_add");
            MemberRule.EditOrDelete = LoadRules(entity, "memberrule_delete");
            //Adjustment
            Adjustment.View = LoadRules(entity, "Adjustment_view");
            Adjustment.EditOrDelete = LoadRules(entity, "Adjustment_edit");
            Adjustment.Add = LoadRules(entity, "Adjustment_add");

            //Stock Unit Conversion
            UnitConversion.View = LoadRules(entity, "Stock_Unit_Conversion_view");
            UnitConversion.Add = LoadRules(entity, "Stock_Unit_Conversion_add");

            //Transaction
            Transaction.EditOrDelete = LoadRules(entity, "transaction_delete");
            Transaction.DeleteAndCopy = LoadRules(entity, "transaction_deleteandcopy");

            // Credit Transaction
            CreditTransaction.EditOrDelete = LoadRules(entity, "credit_transaction_delete");
            CreditTransaction.DeleteAndCopy = LoadRules(entity, "credit_transaction_deleteandcopy");

            // Transaction Detail
            TransactionDetail.EditOrDelete = LoadRules(entity, "transactionDetail_delete");

            //Refund
            Refund.EditOrDelete = LoadRules(entity, "refund_delete");


            //Reports
            DailySaleSummary.View = LoadRules(entity, "dailySaleSummary_view");
            TransactionReport.View = LoadRules(entity, "transactionReport_view");
            TransactionSummaryReport.View = LoadRules(entity, "transactionSummary_view");
            TransactionDetailReport.View = LoadRules(entity, "transactionDetailReport_view");
            DailyTotalTransactions.View = LoadRules(entity, "dailyTotalTransactions_view");
            PurchaseReport.View = LoadRules(entity, "purchaseReport_view");
            PurchaseDiscount.View = LoadRules(entity, "purchaseDiscount_view");
            ItemSummaryReport.View = LoadRules(entity, "itemSummaryReport_view");
            SaleBreakdown.View = LoadRules(entity, "saleBreakdown_view");
            TaxSummaryReport.View = LoadRules(entity, "taxSummaryReport_view");
            TopBestSellerReport.View = LoadRules(entity, "topBestSellerReport_view");
            CustomerSales.View = LoadRules(entity, "customerSales_view");
            OutstandingCustomerReport.View = LoadRules(entity, "outstandingCustomerReport_view");
            CustomerInformation.View = LoadRules(entity, "customerInformation_view");
            ProductReport.View = LoadRules(entity, "productReport_view");
            ReorderPointReport.View = LoadRules(entity, "reorderPointReport_view");
            Consigment.View = LoadRules(entity, "consigment_view");
            ProfitAndLoss.View = LoadRules(entity, "ProfitAndLoss_view");
            AdjustmentReport.View = LoadRules(entity, "AdjustmentReport_view");
            StockTransactionReport.View = LoadRules(entity, "StockTransactionReport_view");
            AverageMonthlyReport.View = LoadRules(entity, "AverageMonthlyReport_view");
        }

        public void Save(int roleId)
        {
            UserRoleId = roleId;
            POSEntities entity = new POSEntities();

            //Delete old entry for this userroldId firstly
            List<APP_Data.RoleManagement> RulesListById = entity.RoleManagements.Where(x => x.UserRoleId == UserRoleId).ToList();
            foreach (APP_Data.RoleManagement rule in RulesListById)
            {
                entity.RoleManagements.Remove(rule);
            }

            //Setting
            CreateRules(entity, Setting.Add, "setting_define");

            //Consignor
            CreateRules(entity, Consignor.EditOrDelete, "consignor_edit");
            CreateRules(entity, Consignor.Add, "consignor_add");

            //Measurement Unit
            CreateRules(entity, MeasurementUnit.EditOrDelete, "measurementunit_edit");
            CreateRules(entity, MeasurementUnit.Add, "measurementunit_add");

            //Currency Exhcange
            CreateRules(entity, CurrencyExchange.Add, "currencyexchange_add");

            //Tax Rate
            CreateRules(entity, TaxRate.EditOrDelete, "taxrate_edit");
            CreateRules(entity, TaxRate.Add, "taxrate_add");

            //City
            CreateRules(entity, City.EditOrDelete, "city_edit");
            CreateRules(entity, City.Add, "city_add");

            //Product
            CreateRules(entity, Product.View, "product_view");
            CreateRules(entity, Product.EditOrDelete, "product_edit");
            CreateRules(entity, Product.Add, "product_add");
            //Brand
            CreateRules(entity, Brand.View, "brand_view");
            CreateRules(entity, Brand.EditOrDelete, "brand_edit");
            CreateRules(entity, Brand.Add, "brand_add");
            //GiftCard
            CreateRules(entity, GiftCard.View, "giftcard_view");
            CreateRules(entity, GiftCard.Add, "giftcard_add");
            CreateRules(entity, GiftCard.EditOrDelete, "giftcard_edit");
            //Customer
            CreateRules(entity, Customer.View, "customer_view");
            CreateRules(entity, Customer.EditOrDelete, "customer_edit");
            CreateRules(entity, Customer.Add, "customer_add");
            CreateRules(entity, Customer.ViewDetail, "customer_viewDetail");
            CreateRules(entity, OutstandingCustomer.View, "outstandingcustomer_view");
            CreateRules(entity, OutstandingCustomer.ViewDetail, "outstandingcustomer_viewDetail");
            //Supplier
            CreateRules(entity, Supplier.View, "supplier_view");
            CreateRules(entity, Supplier.EditOrDelete, "supplier_edit");
            CreateRules(entity, Supplier.Add, "supplier_add");
            CreateRules(entity, Supplier.ViewDetail, "supplier_viewDetail");
            CreateRules(entity, OutstandingSupplier.View, "outstandingsupplier_view");
            CreateRules(entity, OutstandingSupplier.ViewDetail, "outstandingsupplier_viewDetail");

            //Consignment Settlement
            CreateRules(entity, ConsigmentSettlement.View, "consignmentsettlement_view");
            CreateRules(entity, ConsigmentSettlement.EditOrDelete, "consignmentsettlement_delete");

            //Category
            CreateRules(entity, Category.View, "category_view");
            CreateRules(entity, Category.EditOrDelete, "category_edit");
            CreateRules(entity, Category.Add, "category_add");
            //Sub Category
            CreateRules(entity, SubCategory.View, "subcategory_view");
            CreateRules(entity, SubCategory.EditOrDelete, "subcategory_edit");
            CreateRules(entity, SubCategory.Add, "subcategory_add");
            //Counter
            CreateRules(entity, Counter.EditOrDelete, "counter_edit");
            CreateRules(entity, Counter.Add, "counter_add");
            //Purchase
            CreateRules(entity, PurchaseRole.EditOrDelete, "purchase_delete");
            CreateRules(entity, PurchaseRole.Add, "purchase_add");
            CreateRules(entity, PurchaseRole.ViewDetail, "purchase_viewDetail");
            CreateRules(entity, PurchaseRole.View, "purchase_view");
            CreateRules(entity, PurchaseRole.DeleteLog, "purchase_deletelog");
            CreateRules(entity, PurchaseRole.Approved, "purchase_approved");
            //Member Rule
            CreateRules(entity, MemberRule.Add, "memberrule_add");
            CreateRules(entity, MemberRule.EditOrDelete, "memberrule_delete");
            //Adjustment
            CreateRules(entity, Adjustment.View, "Adjustment_view");
            CreateRules(entity, Adjustment.EditOrDelete, "Adjustment_edit");
            CreateRules(entity, Adjustment.Add, "Adjustment_add");

            //Stock Unit Conversion
            CreateRules(entity, UnitConversion.View, "Stock_Unit_Conversion_view");
            CreateRules(entity, UnitConversion.Add, "Stock_Unit_Conversion_add");

            // Transaction
            CreateRules(entity, Transaction.EditOrDelete, "transaction_delete");
            CreateRules(entity, Transaction.DeleteAndCopy, "transaction_deleteandcopy");

            // Credit Transaction
            CreateRules(entity, CreditTransaction.EditOrDelete, "credit_transaction_delete");
            CreateRules(entity, CreditTransaction.DeleteAndCopy, "credit_transaction_deleteandcopy");

            // Transaction Detail
            CreateRules(entity, TransactionDetail.EditOrDelete, "transactionDetail_delete");

            //Refund
            CreateRules(entity, Refund.EditOrDelete, "refund_delete");

            //Reports
            CreateRules(entity, DailySaleSummary.View, "dailySaleSummary_view");
            CreateRules(entity, TransactionReport.View, "transactionReport_view");
            CreateRules(entity, TransactionSummaryReport.View, "transactionSummary_view");
            CreateRules(entity, TransactionDetailReport.View, "transactionDetailReport_view");
            CreateRules(entity, DailyTotalTransactions.View, "dailyTotalTransactions_view");
            CreateRules(entity, PurchaseReport.View, "purchaseReport_view");
            CreateRules(entity, PurchaseDiscount.View, "purchaseDiscount_view");
            CreateRules(entity, ItemSummaryReport.View, "itemSummaryReport_view");
            CreateRules(entity, SaleBreakdown.View, "saleBreakdown_view");
            CreateRules(entity, TaxSummaryReport.View, "taxSummaryReport_view");
            CreateRules(entity, TopBestSellerReport.View, "topBestSellerReport_view");
            CreateRules(entity, CustomerSales.View, "customerSales_view");
            CreateRules(entity, OutstandingCustomerReport.View, "outstandingCustomerReport_view");
            CreateRules(entity, CustomerInformation.View, "customerInformation_view");
            CreateRules(entity, ProductReport.View, "productReport_view");
            CreateRules(entity, ReorderPointReport.View, "reorderPointReport_view");
            CreateRules(entity, Consigment.View, "consigment_view");
            CreateRules(entity, ProfitAndLoss.View, "ProfitAndLoss_view");
            CreateRules(entity, AdjustmentReport.View, "AdjustmentReport_view");
            CreateRules(entity, StockTransactionReport.View, "StockTransactionReport_view");
            CreateRules(entity, AverageMonthlyReport.View, "AverageMonthlyReport_view");
        }

        private void CreateRules(POSEntities entity, Boolean IsAllowed, String Rule)
        {
            APP_Data.RoleManagement obj = new APP_Data.RoleManagement();
            obj.UserRoleId = UserRoleId;
            obj.IsAllowed = IsAllowed;
            obj.RuleFeature = Rule;
            entity.RoleManagements.Add(obj);
            entity.SaveChanges();
        }

        private Boolean LoadRules(POSEntities entity, String Rule)
        {
            APP_Data.RoleManagement obj = entity.RoleManagements.Where(x => x.RuleFeature == Rule && x.UserRoleId == UserRoleId).FirstOrDefault();
            Boolean result = false;
            if (obj != null) result = obj.IsAllowed;

            return result;
        }

        public List<bool> IsAllAllowedForOperation(int roleId)
        {
            // First, Make a List of Rule Name which we will show in Role Management Form in Operation Pannel
            #region Rule Name List
            List<string> RuleNameList = new List<string>(new string[]{
            "product_view",
            "product_view",
            "product_edit",

            "brand_view",
            "brand_edit",
            "brand_add",

            "giftcard_view",
            "giftcard_add",
            "giftcard_edit",
   
            "customer_view",
            "customer_edit",
            "customer_add",
            "customer_viewDetail",

            "category_view",
            "category_edit",
            "category_add",

            "subcategory_view",
            "subcategory_edit",
            "subcategory_add",

            "counter_edit",
            "counter_add",

            "supplier_view",
            "supplier_edit",
            "supplier_add",
            "supplier_viewDetail",

            "purchase_delete",
            "purchase_add",
            "purchase_viewDetail",
            "purchase_view",

            "memberrule_add",
            "memberrule_delete",

            "Adjustment_view",
            "Adjustment_edit",
            "Adjustment_add",

            "transaction_delete",
            "transaction_deleteandcopy",

            "credit_transaction_delete",
            "credit_transaction_deleteandcopy",

            "transactionDetail_delete",

            "refund_delete"
            });
            #endregion

            POSEntities entity = new POSEntities();
            var obj = (from rm in entity.RoleManagements.AsEnumerable()
                       join r in RuleNameList on rm.RuleFeature.Trim() equals r
                       where rm.UserRoleId == roleId
                       select rm.IsAllowed).ToList();

            return obj;
        }

        public List<bool> IsAllAllowedForReport(int roleId)
        {
            // First, Make a List of Rule Name which we will show in Role Management Form in Report Pannel
            #region Rule Name List
            List<string> RuleNameList = new List<string>(new string[]{
            "dailySaleSummary_view",
            "transactionReport_view",
            "transactionSummary_view",
            "transactionDetailReport_view",
             "dailyTotalTransactions_view",
             "purchaseReport_view",
           "purchaseDiscount_view",
             "itemSummaryReport_view",
           "saleBreakdown_view",
           "taxSummaryReport_view",
             "topBestSellerReport_view",
             "customerSales_view",
            "outstandingCustomerReport_view",
            "customerInformation_view",
            "productReport_view",
            "reorderPointReport_view",
          "consigment_view",
            "ProfitAndLoss_view",
           "AdjustmentReport_view",
            "StockTransactionReport_view",
            "AverageMonthlyReport_view"
            });
            #endregion

            POSEntities entity = new POSEntities();
            var obj = (from rm in entity.RoleManagements.AsEnumerable()
                       join r in RuleNameList on rm.RuleFeature.Trim() equals r
                       where rm.UserRoleId == roleId
                       select rm.IsAllowed).ToList();

            return obj;
        }
    }

    public class RoleManagementModel
    {
        public Boolean View { get; set; }
        public Boolean EditOrDelete { get; set; }
        public Boolean Add { get; set; }
        public Boolean ViewDetail { get; set; }
        public Boolean DeleteAndCopy { get; set; }
        public Boolean DeleteLog { get; set; }
        public Boolean Approved { get; set; }
    }

    public static class SettingController
    {
        public static Boolean UseStockAutoGenerate
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "UseStockAutoGenerate");
                if (currentSet != null)
                {
                    return Convert.ToBoolean(currentSet.Value);
                }

                return false;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "UseStockAutoGenerate");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "UseStockAutoGenerate";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string FooterPage
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "FooterPage");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "FooterPage");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "FooterPage";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string Logo
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "Logo");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "Logo");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "Logo";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string ShopName
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "shop_name");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "shop_name");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "shop_name";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string BranchName
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "branch_name");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "branch_name");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "branch_name";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string PhoneNo
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "phone_number");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "phone_number");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "phone_number";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string OpeningHours
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "opening_hours");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "opening_hours");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "opening_hours";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string DefaultTaxRate
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_tax_rate");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_tax_rate");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "default_tax_rate";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string SelectDefaultPrinter
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_printer");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_printer");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "default_printer";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static int DefaultTopSaleRow
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_top_sale_row");
                if (currentSet != null)
                {
                    return Convert.ToInt32(currentSet.Value);
                }

                return 0;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_top_sale_row");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "default_top_sale_row";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static int DefaultCurrency
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_currency");
                if (currentSet != null)
                {
                    return Convert.ToInt32(currentSet.Value);
                }
                return 0;
            }

            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentset = entity.Settings.FirstOrDefault(x => x.Key == "default_currency");
                if (currentset == null)
                {
                    currentset = new APP_Data.Setting();
                    currentset.Key = "default_currency";
                    currentset.Value = value.ToString();
                    entity.Settings.Add(currentset);
                }
                else
                {
                    currentset.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static int DefaultNoOfCopies
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_noOfCopies");
                if (currentSet != null)
                {
                    return Convert.ToInt32(currentSet.Value);
                }

                return 1;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_noOfCopies");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "default_noOfCopies";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string Company_StartDate
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "Company_StartDate");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }
                return string.Empty;
            }

            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentset = entity.Settings.FirstOrDefault(x => x.Key == "Company_StartDate");
                if (currentset == null)
                {
                    currentset = new APP_Data.Setting();
                    currentset.Key = "Company_StartDate";
                    currentset.Value = value.ToString();
                    entity.Settings.Add(currentset);
                }
                else
                {
                    currentset.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static int GetExchangeRate(int Id)
        {
            POSEntities entity = new POSEntities();
            Currency currentCurrency = entity.Currencies.FirstOrDefault(x => x.Id == Id);
            if (currentCurrency != null)
            {
                return Convert.ToInt32(currentCurrency.LatestExchangeRate);
            }
            return 0;
        }
        public static void SetExchangeRate(int Id, int value)
        {
            POSEntities entity = new POSEntities();
            Currency currentCurrency = entity.Currencies.FirstOrDefault(x => x.Id == Id);
            currentCurrency.LatestExchangeRate = value;
            entity.SaveChanges();
        }

        public static int DefaultCity
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_city_id");
                if (currentSet != null)
                {
                    return Convert.ToInt32(currentSet.Value);
                }
                return 0;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_city_id");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "default_city_id";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }


        public static string Use
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_tax_rate");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "default_tax_rate");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "default_tax_rate";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }


        internal static object CompanyStartDate()
        {
            throw new NotImplementedException();
        }
    }

    public static class DatabaseControlSetting
    {
        public static string _ServerName
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["_ServerName"];
            }
        }
        /// <summary>
        /// Get or Set the Database's Name
        /// </summary>
        public static string _DBName
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["_DBName"];
            }
        }
        /// <summary>
        /// Get or Set the Database's Login User
        /// </summary>
        public static string _DBUser
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["_DBUser"];
            }
        }
        /// <summary>
        /// Get or Set the Database's Login Password
        /// </summary>
        public static string _DBPassword
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["_DBPassword"];
            }
        }

    }


    public class RestoreHelper
    {
        public RestoreHelper()
        {

        }

        public void RestoreDatabase(String databaseName, String backUpFile, String serverName, String userName, String password)
        {
            ServerConnection connection = new ServerConnection(serverName, userName, password);
            Server sqlServer = new Server(connection);
            string dbaddr = string.Empty;
            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
            {
                dbaddr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            }

            SqlConnection conn = new SqlConnection(dbaddr);
            string s = conn.State.ToString();
            conn.Close();
            SqlConnection.ClearPool(conn);
            Restore rstDatabase = new Restore();
            rstDatabase.Action = RestoreActionType.Database;
            rstDatabase.Database = databaseName;
            BackupDeviceItem bkpDevice = new BackupDeviceItem(backUpFile, DeviceType.File);
            rstDatabase.Devices.Add(bkpDevice);
            rstDatabase.ReplaceDatabase = true;
            rstDatabase.Complete += new ServerMessageEventHandler(sqlRestore_Complete);
            rstDatabase.PercentCompleteNotification = 10;
            rstDatabase.PercentComplete += new PercentCompleteEventHandler(sqlRestore_PercentComplete);
            rstDatabase.SqlRestore(sqlServer);
            sqlServer.Refresh();
        }

        public event EventHandler<PercentCompleteEventArgs> PercentComplete;

        void sqlRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            if (PercentComplete != null)
                PercentComplete(sender, e);
        }

        public event EventHandler<ServerMessageEventArgs> Complete;

        void sqlRestore_Complete(object sender, ServerMessageEventArgs e)
        {
            if (Complete != null)
                Complete(sender, e);
        }
    }

    public class BackupHelper
    {
        public BackupHelper()
        {

        }

        public void BackupDatabase(String databaseName, String userName, String password, String serverName, String destinationPath, ref bool isBackUp)
        {
            Backup sqlBackup = new Backup();

            sqlBackup.Action = BackupActionType.Database;
            sqlBackup.BackupSetDescription = "ArchiveDataBase:" + DateTime.Now.ToShortDateString();
            sqlBackup.BackupSetName = "Archive";

            sqlBackup.Database = databaseName;

            BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);
            ServerConnection connection = new ServerConnection(serverName, userName, password);
            Server sqlServer = new Server(connection);

            Database db = sqlServer.Databases[databaseName];

            sqlBackup.Initialize = true;
            sqlBackup.Checksum = true;
            sqlBackup.ContinueAfterError = true;

            sqlBackup.Devices.Add(deviceItem);
            sqlBackup.Incremental = false;

            sqlBackup.ExpirationDate = DateTime.Now.AddDays(30);
            sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

            sqlBackup.FormatMedia = false;
            try
            {
                sqlBackup.SqlBackup(sqlServer);
                isBackUp = true;
            }
            catch
            {
                MessageBox.Show("Please check the database if it's properly installed.");
            }
        }
    }

    #region PrintFunctions

    public static class PrintDoc
    {
        private static Boolean isStickerSize = false;
        private static Boolean isSlipSize = false;
        private static Boolean isA4Size = false;
        private static IList<Stream> m_streams;
        private static int m_currentPageIndex;

        #region Printing Functions

        private static void Print()
        {
            try
            {
                if (m_streams == null || m_streams.Count == 0)
                    return;
        
                PrintDocument printDoc = new PrintDocument();

                if (isStickerSize)
                    printDoc.PrinterSettings.PrinterName = DefaultPrinter.BarcodePrinter;
                else if (isSlipSize)
                    printDoc.PrinterSettings.PrinterName = DefaultPrinter.SlipPrinter;
                else
                    printDoc.PrinterSettings.PrinterName = DefaultPrinter.A4Printer;

                if (!printDoc.PrinterSettings.IsValid)
                {
                    string msg = String.Format("Can't find printer \"{0}\".", DefaultPrinter.A4Printer);
                    System.Diagnostics.Debug.WriteLine(msg);
                    return;
                }
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                printDoc.Print();

                printDoc.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void PrintReport(ReportViewer rv)
        {
            isStickerSize = false;
            m_currentPageIndex = 0;
            m_streams = null;
            Export(rv.LocalReport);
            Print();
            //  Dispose();
            rv.LocalReport.ReleaseSandboxAppDomain();
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <param name="Type">BarcodeStricker||Slip </param>
        public static void PrintReport(ReportViewer rv, String Type)
        {
            m_currentPageIndex = 0;
            m_streams = null;
            isStickerSize = false; isA4Size = false; isSlipSize = false;
            if (Type == "BarcodeSTicker")
            {
                isStickerSize = true;
            }
            else if (Type == "A4 Printer")
            {
                isA4Size = true;
            }
            else
            {
                isSlipSize = true;
            }

            Export(rv.LocalReport);

            Print();

            //  Dispose();
            rv.LocalReport.ReleaseSandboxAppDomain();
        }

        // Export the given report as an EMF (Enhanced Metafile) file.
        private static void Export(LocalReport report)
        {
            string deviceInfo = string.Empty;
            if (isStickerSize)
            {
                deviceInfo =
                  @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>3in</PageWidth>                
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
                </DeviceInfo>";
            }
            else if (isSlipSize)
            {
                deviceInfo =
                  @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>3in</PageWidth>                
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            }
            else
            {
                deviceInfo =
                  @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8in</PageWidth>
                <PageHeight>10.5in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            }
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            //ev.Graphics.DrawImage(pageImage, 0, 0);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        #endregion
    }

    public static class ExportReport
    {
        public static void Excel(ReportViewer rv, String FileName)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = rv.LocalReport.Render(
               "Excel", null, out mimeType, out encoding,
                out extension,
               out streamids, out warnings);
            try
            {
                FileStream fs = new FileStream(@"D:\Reports\" + FileName + DateTime.Now.ToString("ddMMyyyy") + ".xls", FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                MessageBox.Show(@"Report file is saved in D\Reports\" + FileName + DateTime.Now.ToString("ddMMyyyy") + ".xls", "Saving Complete");
            }
            catch (DirectoryNotFoundException message)
            {
                MessageBox.Show(@"The file patch (D:\Reports) isn't exist. Please check and create Reports folder in the Drive D", "Error");
            }
        }
    }

    public static class DefaultPrinter
    {
        public static string BarcodePrinter
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "barcode_printer");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "barcode_printer");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "barcode_printer";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string A4Printer
        {
            get
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "a4_printer");
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == "a4_printer");
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = "a4_printer";
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }

        public static string SlipPrinter
        {
            get
            {
                POSEntities entity = new POSEntities();
                string key = "slip_printer_counter" + MemberShip.CounterId.ToString();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == key);
                if (currentSet != null)
                {
                    return Convert.ToString(currentSet.Value);
                }

                return string.Empty;
            }
            set
            {
                POSEntities entity = new POSEntities();
                string key = "slip_printer_counter" + MemberShip.CounterId.ToString();
                APP_Data.Setting currentSet = entity.Settings.FirstOrDefault(x => x.Key == key);
                if (currentSet == null)
                {
                    currentSet = new APP_Data.Setting();
                    currentSet.Key = key;
                    currentSet.Value = value.ToString();
                    entity.Settings.Add(currentSet);
                }
                else
                {
                    currentSet.Value = value.ToString();
                }
                entity.SaveChanges();
            }
        }
    }

    #endregion


}
