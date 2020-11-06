using System;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Northwind.NorthwindData;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;

namespace Northwind
{
    class Program
    {
        
        static void Main(string[] args)
        {
           
            var myData = GetData();

            if (myData != null)
            {
                //Create list of JASON,XML,BINARY files sizes .Data handling
                var fileCollection = new List<FileSizes>() {
                    new FileSizes{ FileName="json", Size =getJSONSize(myData) },
                    new FileSizes{ FileName="xml", Size= getXMLSize(myData)},
                    new FileSizes{ FileName="binary", Size = getBinaryFileSize(myData)}
                };

                // sorting list by order
                var sortedList = fileCollection.OrderBy(el => el.Size).ToList();
               
                //output
                sortedList.ForEach(item => Console.WriteLine($"The file {item.FileName} has size of {item.Size} bytes"));
               
            }

            //******************************************************************************
            //Question 2 function call
            QueryingCityCastumer();
            //******************************************************************************
        }

        // Sterializing JASON file and return size file
        public static long getJSONSize(List<ProcuctCategory> list)
        {

            var json = JsonSerializer.Serialize(list);
            var jsonFileName = "products.json";
            File.WriteAllText(jsonFileName, json);
            return File.Open(jsonFileName, FileMode.Open).Length;
            
        }

        // Sterializing XML file and return size file
        public static long getXMLSize(List<ProcuctCategory> list) {

            using (StringWriter writer = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ProcuctCategory>));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                XmlWriter xmlWriter = XmlWriter.Create(writer, settings);
                serializer.Serialize(xmlWriter, list, namespaces);

                var xmlFileName = "products.xml";
                File.WriteAllText(xmlFileName, writer.ToString());
                return File.Open(xmlFileName, FileMode.Open).Length;
                

            }
        }

        // Sterializing BINARY file and return size file
        public static long getBinaryFileSize(List<ProcuctCategory> list) {
            using (Stream stream = File.Open("products.bin", FileMode.Create))
            {
                var bformatter = new BinaryFormatter();

                bformatter.Serialize(stream, list);
                return stream.Length;
                
            }
        }

        public static List<ProcuctCategory> GetData()
        {
            try
            { 
                using var context = new northwindContext();  //conection with northwindContext file

                //create list of prodacts and categories
                var listProdCategories = (from cat in context.Categories  
                                          join prod in context.Products
                                          on cat.CategoryId equals prod.CategoryId
                                          select new ProcuctCategory  // using new calss properties = info from product and category tables
                                          {
                                              CategoryName = cat.CategoryName,
                                              CategoryDescription = cat.Description,
                                              CategoryPicture = cat.Picture,
                                              ProductId = prod.ProductId,
                                              ProductName = prod.ProductName,
                                              ProductSupplierId = prod.SupplierId,
                                              ProductCategoryId = prod.CategoryId,
                                              ProductQuantityPerUnit = prod.QuantityPerUnit,
                                              ProductUnitPrice = prod.UnitPrice,
                                              ProductUnitsInStock = prod.UnitsInStock,
                                              ProductUnitsOnOrder = prod.UnitsOnOrder,
                                              ProductReorderLevel = prod.ReorderLevel,
                                              ProdcutDiscontinued = prod.Discontinued
                                              

                                          }).ToList();


                return listProdCategories;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //******************************************************************************************************************************
        // Question 2
        //Create a console application that prompts the user for a city and then lists the company names for Northwind customers in that cit
        public static void QueryingCityCastumer()
        {
            try {

                using (var database = new northwindContext())
                {
                    WriteLine("**************************************");
                    Write("Enter the name of a city: ");
                    string input = ReadLine();
                    //Create a query for all customers from that city
                    var customers = database.Customers.Where(e => e.City == input).ToList();
                    Console.WriteLine($"There are {customers.Count} customers in {input}");
                    customers.ForEach(item => Console.WriteLine($"{item.CompanyName}"));
                    //return customers.Fo
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
            }
          
        }

        //************************************************************************************************************************************

    }


    // create new calss to use all info from product and catecory tables
    [Serializable()]
    public class ProcuctCategory {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public byte[] CategoryPicture { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductSupplierId { get; set; }
        public int? ProductCategoryId { get; set; }
        public string ProductQuantityPerUnit { get; set; }
        public decimal? ProductUnitPrice { get; set; }
        public short? ProductUnitsInStock { get; set; }
        public short? ProductUnitsOnOrder { get; set; }
        public short? ProductReorderLevel { get; set; }
        public bool ProdcutDiscontinued { get; set; }


   
    }

    //create object for file size
    public class FileSizes {
        public string FileName { get; set; }
        public long Size { get; set; }
    }

    

}
