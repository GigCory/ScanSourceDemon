using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Container = SimpleInjector.Container;
using assessment_platform_developer.Commands;
using System.Text.RegularExpressions;
using assessment_platform_developer.Queries;
namespace assessment_platform_developer
{
	public partial class Customers : Page
	{
		private static List<CustomerQueryDTO> customersQuery = new List<CustomerQueryDTO>();
        private static List<CustomerCommandDTO> customerCommand = new List<CustomerCommandDTO>();
        protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
				var customerService = testContainer.GetInstance<ICustomerQuery>();
				var allCustomers = customerService.GetAllCustomers();
				ViewState["Customers"] = allCustomers;
			}
			else
			{
                customersQuery = (List<CustomerQueryDTO>)ViewState["Customers"];
			}
			PopulateCustomerListBox();
			PopulateCustomerDropDownLists();
		}
		private void PopulateCustomerDropDownLists()
		{
			if (!IsPostBack)
			{
				var countryList = Enum.GetValues(typeof(Countries))
				.Cast<Countries>()
				.Select(c => new ListItem
				{
					Text = c.ToString(),
					Value = ((int)c).ToString()
				})
				.ToArray();
				CountryDropDownList.Items.Clear();
				CountryDropDownList.Items.AddRange(countryList);
				var provinceList = Enum.GetValues(typeof(CanadianProvinces))
					.Cast<CanadianProvinces>()
					.Select(p => new ListItem
					{
						Text = p.ToString(),
						Value = ((int)p).ToString()
					})
					.ToArray();
				StateDropDownList.Items.Clear();
				StateDropDownList.Items.AddRange(provinceList);
			}
		}
        protected void CustomersDDL_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
                var customer= customersQuery.FirstOrDefault(c => c.Name ==CustomersDDL.SelectedValue);
                CustomerName.Text = customer.Name;
                CustomerAddress.Text = customer.Address;
                CustomerEmail.Text = customer.Email;
                StateDropDownList.SelectedValue = customer.State;
                CountryDropDownList.SelectedValue = customer.Country;
            }
		}
		protected void CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			Province province = new Province();

			var provinceList = province.ProvinceList(CountryDropDownList.SelectedIndex)
				.Select(p => new ListItem
				{
					Text = p.ProvinceName.ToString(),
					Value = p.ProvinceName.ToString()
				})
				.ToArray();
			StateDropDownList.Items.Clear();
			StateDropDownList.Items.AddRange(provinceList);
		}
		protected void PopulateCustomerListBox()
		{
			CustomersDDL.Items.Clear();
			var storedCustomers = customersQuery.Select(c => new ListItem(c.Name)).ToArray();
			if (storedCustomers.Length != 0)
			{
				CustomersDDL.Items.AddRange(storedCustomers);
				return;
			}
			CustomersDDL.Items.Add(new ListItem("Add new customer"));
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			var customer = new CustomerCommandDTO
            {
				Name = CustomerName.Text,
				Address = CustomerAddress.Text,
				City = CustomerCity.Text,
				State = StateDropDownList.SelectedValue,
				Zip = CustomerZip.Text,
				Country = CountryDropDownList.SelectedValue,
				Email = CustomerEmail.Text,
				Phone = CustomerPhone.Text,
				Notes = CustomerNotes.Text,
				ContactName = ContactName.Text,
				ContactPhone = CustomerPhone.Text,
				ContactEmail = CustomerEmail.Text
			};
			var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
			var customerService = testContainer.GetInstance<ICustomerCommand>();
			customerService.AddCustomer(customer);
			customerCommand.Add(customer);
			customersQuery.Add(new CustomerQueryDTO
            {
                Name = customer.Name,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                Zip = customer.Zip,
                Country = customer.Country,
                Email = customer.Email,
                Phone = customer.Phone,
                Notes = customer.Notes,
                ContactName = customer.ContactName,
                ContactPhone = customer.ContactPhone,
                ContactEmail = customer.ContactEmail
            });
            CustomersDDL.Items.Add(new ListItem(customer.Name));
			CustomerName.Text = string.Empty;
			CustomerAddress.Text = string.Empty;
			CustomerEmail.Text = string.Empty;
			CustomerPhone.Text = string.Empty;
			CustomerCity.Text = string.Empty;
			StateDropDownList.SelectedIndex = 0;
			CustomerZip.Text = string.Empty;
			CountryDropDownList.SelectedIndex = 0;
			CustomerNotes.Text = string.Empty;
			ContactName.Text = string.Empty;
			ContactPhone.Text = string.Empty;
			ContactEmail.Text = string.Empty;
		}

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            var customer = new CustomerCommandDTO
            {
				ID = CustomersDDL.SelectedIndex,
                Name = CustomerName.Text,
                Address = CustomerAddress.Text,
                City = CustomerCity.Text,
                State = StateDropDownList.SelectedValue,
                Zip = CustomerZip.Text,
                Country = CountryDropDownList.SelectedValue,
                Email = CustomerEmail.Text,
                Phone = CustomerPhone.Text,
                Notes = CustomerNotes.Text,
                ContactName = ContactName.Text,
                ContactPhone = CustomerPhone.Text,
                ContactEmail = CustomerEmail.Text
            };
            var updateCustomer = customersQuery.Find(x => x.Name == CustomersDDL.SelectedValue);
            var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
            var customerService = testContainer.GetInstance<ICustomerCommand>();
            customerService.UpdateCustomer(customer);
        }
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            var deleteCustomer = customersQuery.Find(x => x.Name == CustomersDDL.SelectedValue);
            var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
            var customerService = testContainer.GetInstance<ICustomerCommand>();
            customerService.DeleteCustomer(deleteCustomer.ID);
            customersQuery.Remove(deleteCustomer);
            PopulateCustomerListBox();
            CustomerName.Text = string.Empty;
			CustomerAddress.Text = string.Empty;
			CustomerEmail.Text = string.Empty;
			CustomerPhone.Text = string.Empty;
			CustomerCity.Text = string.Empty;
			StateDropDownList.SelectedIndex = 0;
			CustomerZip.Text = string.Empty;
			CountryDropDownList.SelectedIndex = 0;
			CustomerNotes.Text = string.Empty;
			ContactName.Text = string.Empty;
			ContactPhone.Text = string.Empty;
			ContactEmail.Text = string.Empty;
		}
    }
}