using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using Statos.Model.Accounts;
using Statos.Model.Blogs;
using Statos.Model.Contents;
using Statos.Model.Products;

namespace Statos.Repository
{
    public class Initializer : DropCreateDatabaseAlways<StatosContext>
    {
        protected override void Seed(StatosContext context)
        {
            var accounts = new List<Account>
                              {
                                  new Account
                                      {
                                          Email = "mansour@gmail.com",
                                          FirstName = "Mansour",
                                          Id = 1,
                                          LastName = "Ghanbari",
                                          Password = "123456",
                                          SecurityEmail = "Ghanbari@gmail.com",
                                          Sex = "Male",
                                          UserName = "MansourGh",
                                          CreationTime = DateTime.Now,
                                          MobileNumber = "23433435423",
                                          PhoneNumber = "387458374653874",
                                          UserRoles = new Collection<UserRole>()
                                      }
                              };
            var categories = new List<Category>
                               {
                                       new Category
                                       {
                                           Id = 1,
                                           Name = "Wood",
                                           Products = new Collection<Product>()
                                       },
                                       new Category
                                           {
                                               Id=2,
                                               Name = "Toy",
                                               Products = new Collection<Product>()
                                           }
                                    
                               };
            var brands = new List<Brand>
                {
                    new Brand
                        {
                            Id = 1,
                            Name = "snow",
                            
                        },
                    new Brand
                        {
                            Id = 2,
                            Name = "candom"
                        }

                };

            var products = new List<Product>
                              {
                                  new Product
                                      {
                                          Brand=brands.Single(b=>b.Name=="candom"),
                                          Description = "so I dont know what to say about that",
                                          Id = 1,
                                          Name = "Wood",
                                          Price = 2342,
                                          CreationTime = DateTime.Now,
                                          Picture = "Pic",
                                         // Categories=categories,
                                      }
                                      ,new Product
                                          {
                                              CreationTime = DateTime.Now,
                                              Id = 2,
                                              Brand=brands.Single(b=>b.Name=="candom"),
                                             // Categories= categories,
                                              Description = "toy is somthing for kids !",
                                              Name = "Auto",
                                              Picture = "sdfs",
                                              Price = 342234
                                              
                                          }
                                           ,new Product
                                          {
                                              CreationTime = DateTime.Now,
                                              Id =3,
                                              Brand=brands.Single(b=>b.Name=="candom"),
                                             // Categories=new Collection<Category>(),
                                              Description = "toy is somthing for kids !",
                                              Name = "Auto",
                                              Picture = "sdfs",
                                              Price = 342234
                                              
                                          }
                                           ,new Product
                                          {
                                              CreationTime = DateTime.Now,
                                              Id = 4,
                                              Brand=brands.Single(b=>b.Name=="snow"),
                                             // Categories=new Collection<Category>(),
                                              Description = "toy is somthing for kids !",
                                              Name = "Auto",
                                              Picture = "sdfs",
                                              Price = 342234
                                              
                                          } ,new Product
                                          {
                                              CreationTime = DateTime.Now,
                                              Id =5,
                                              Brand=brands.Single(b=>b.Name=="snow"),
                                              //Categories=new Collection<Category>(),
                                              Description = "toy is somthing for kids !",
                                              Name = "Auto",
                                              Picture = "sdfs",
                                              Price = 342234
                                              
                                          } ,new Product
                                          {
                                              CreationTime = DateTime.Now,
                                              Id = 6,
                                              Brand=brands.Single(b=>b.Name=="snow"),
                                              // Categories=new Collection<Category>(), 
                                              Description = "toy is somthing for kids !",
                                              Name = "Auto",
                                              Picture = "sdfs",
                                              Price = 342234
                                              
                                          } ,new Product
                                          {
                                              CreationTime = DateTime.Now,
                                              Id = 7,
                                              Brand=brands.Single(b=>b.Name=="snow"),
                                              //Categories=new Collection<Category>(),
                                              Description = "toy is somthing for kids !",
                                              Name = "Auto",
                                              Picture = "sdfs",
                                              Price = 342234
                                              
                                          } ,new Product
                                          {
                                              CreationTime = DateTime.Now,
                                              Id =8,
                                              Brand=brands.Single(b=>b.Name=="snow"),
                                            //  Categories=new Collection<Category>(),
                                              Description = "toy is somthing for kids !",
                                              Name = "Auto",
                                              Picture = "sdfs",
                                              Price = 342234
                                              
                                          } ,new Product
                                          {
                                              CreationTime = DateTime.Now,
                                              Id = 9,
                                              Brand=brands.Single(b=>b.Name=="snow"),
                                              //Categories=new Collection<Category>(),
                                              Description = "toy is somthing for kids !",
                                              Name = "Auto",
                                              Picture = "sdfs",
                                              Price = 342234
                                              
                                          } ,new Product
                                          {
                                              CreationTime = DateTime.Now,
                                              Id = 10,
                                              Brand=brands.Single(b=>b.Name=="snow"),
                                          //    Categories=new Collection<Category>(),
                                              Description = "toy is somthing for kids !",
                                              Name = "Auto",
                                              Picture = "sdfs",
                                              Price = 342234
                                              
                                          }     
                              };
            var contents = new List<Content>
                {
                    new Content
                        {

                            AboutText = "How do I contact wiggle?If you are contacting "+
                            "us about an order you have already placed, please use the contact form in your order"+
                            " history page.How do I access my order history?Please sign in with the account that the "+
                            "order was placed with Once on the 'My Account' page on the left navigation menu select "+
                            "This page is now displaying the last 10 orders that have been placed, please find the order" +
                                                                " you would like to place the query about and select ",

                            Address = "Russhia, moskow",
                            CreationTime = DateTime.Now,
                            Id = 1,
                            Mobile = 342342342352,
                            Phone = 345345345646,
                            FaceBook = "slfk",
                            GooglePlus="sdkfj",
                            HeaderImage="ksjdfl",
                            Twitter = "s;lkdjf"

                        }
                };

            var posts = new List<Blog>
                {
                    new Blog
                        {
                            Id = 1,
                            Title = "this is a Blog Post and only some character will be shown",
                            Body = "this is the Body of the post" +
                                   "After you save the file and restart the Apache Web Server, " +
                                   "any PHP file saved with that .bozo extension would display your " +
                                   "PHP coding just like a normal PHP file. Now close and save the file. " +
                                   "We have to restart the Apache Web Server for everything to take effect." +
                                   " If Apache is running, turn it off by clicking the  button "+
                                    "that says,  located in the  Section of the System Preferences.To restart Apache "+
                                    "click on the button. Apache will now be running. We will be writing a small PHP script that will"+
                                    " give us information about the PHP installation.Now that you have Apache running, it would be great"+
                                    " to write your own PHP scripts and run them locally on your Mac. This is the most difficult part and"+
                                    " if you get past this, everything is downhill with ease.By default, PHP is disabled along with other features"+
                                    " of the Apache Web Server, but we are going to concentrate on enabling PHP. ",
                            CreationTime = DateTime.Now,
                            UrlSlug = "this-is-a-Blog-Post-and-only-some-character-will-be-shown"
                        }
                };

            accounts.ForEach(x => context.Account.Add(x));
            categories.ForEach(x => context.Category.Add(x));
            products.ForEach(x => context.Product.Add(x));
            contents.ForEach(x => context.Content.Add(x));
            posts.ForEach(x => context.Blog.Add(x));
            brands.ForEach(x => context.Brand.Add(x));

        }
    }
}
