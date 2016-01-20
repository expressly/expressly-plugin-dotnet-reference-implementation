using System;
using System.Collections.Generic;
using System.Web;
using Expressly.Api;

namespace Expressly.SDK.Sample.MVC.Services
{
    /// <summary>
    /// Implementation of the IMerchantProvider interface, 
    /// where all the merchant side behaviour necessary for the functioning of the Expressly Plugin are implemented. 
    /// </summary>
    public class ExpresslyMerchantProvider : IMerchantProvider
    {
        public Migration getCustomerData(string email)
        {
            Migration migration = new Migration
            {
                customer = new Customer { email = "test@test.com" },
                metada = new Metadata { locale = "Ru-ru" }
            };

            return migration;
        }

        public InvoiceList getInvoices(InvoiceListRequest request)
        {

            var orderList = new List<Order>();

            var order = new Order
            {
                id = "ORDER-5321311",
                date = "2015-07-10",
                itemCount = 2,
                coupon = "COUPON",
                currency = "GBP",
                preTaxTotal = 100.00,
                postTaxTotal = 110.00,
                tax = 10.00
            };

            orderList.Add(order);

            var invoiceList = new InvoiceList();

            var invoce = new Invoice
            {
                email = "testa@test.com",
                orderCount = 1,
                preTaxTotal = 100.00,
                postTaxTotal = 110.00,
                tax = 10.00,
                orders = orderList
            };

            invoiceList.invoices = new List<Invoice> { invoce };



            return invoiceList;
        }

        public EmailStatusList checkEmails(EmailAddressRequest request)
        {
            var emailStatusList = new EmailStatusList
            {
                deleted = new List<string> { "g@test.com", "i@test.com" },
                existing = new List<string> { "a@test.com", "b@test.com" },
                pending = new List<string> { "e@test.com", "f@test.com" }

            };

            return emailStatusList;
        }


        public void popupHandler(string campaignCustomerUuid, HttpResponse response)
        {
            response.RedirectToRoute(new
            {
                controller = "Home",
                action = "HandleMigrationPopup",
                campaignCustomerUuid
            });
        }

        public void handleCustomerAlreadyExists(string email, HttpResponse response)
        {
            response.RedirectToRoute(new
            {
                controller = "Home",
                action = "CustomerAlreadyExists",
                email
            });
        }

        public bool checkCustomerAlreadyExists(string email)
        {
            return false;
        }

        public bool sendPasswordResetEmail(string customerReference)
        {
            return true;
        }

        public string registerCustomer(Customer customerData)
        {
            return "test@gmail.com";
        }

        public void loginAndRedirectCustomer(string customerUserReference, HttpResponse response)
        {
            response.RedirectToRoute(new
            {
                controller = "Home",
                action = "Login",
                customerUserReference
            });
        }

        public bool createCustomerCart(string customerReference, Cart cart)
        {
            return true;
        }
    }
}
