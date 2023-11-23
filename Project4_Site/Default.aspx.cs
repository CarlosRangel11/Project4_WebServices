using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project4_Site {
    public partial class _Default : Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnCreatePark_Click(object sender, EventArgs e) {
            XMLService.Service1Client proxy = new XMLService.Service1Client();
            XMLService.Park park = new XMLService.Park();   // new park object to send as arg

            // Gather all of the textbox info
            park.Name = txtParkName.Text;
            park.Park_Type = txtParkType.Text;
            park.Owner = txtParkOwner.Text;
            park.Reservation_Address = txtParkReservation_Address.Text;
            park.Reservation_Url = txtParkReservation_URL.Text;
            park.Established_In = txtParkEstablished_In.Text;

            // Since Neighboring States is an array of strings, we have to parse this textbox. 
            string Neighboring_States_Buffer = txtParkNeighboring_States.Text;
            park.Neighboring_States = Neighboring_States_Buffer.Split(',')
                                           .Select(state => state.Trim())
                                           .Where(state => !string.IsNullOrWhiteSpace(state))
                                           .ToArray();

            proxy.addPark(park);


            // TODO:::::::::::::::::::::::::::::::::::::::::::::
            // FIX THE FORMATTING, IT UGLY AF
            // Display the new xml file
            string xmlDoc_string = proxy.GetXMLDoc();


            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(xmlDoc_string);

            XmlView.Document = xmlDoc;
            XmlView.Visible = true;

            proxy.Close();
        }

        protected void btnVerifyXML_Click(object sender, EventArgs e) {
            // Test URLs
            // https://www.public.asu.edu/~carange4/Parks.xml
            // https://www.public.asu.edu/~carange4/Incorrect_Park1.xml
            // https://www.public.asu.edu/~carange4/Incorrect_Park2.xml
            // https://www.public.asu.edu/~carange4/Incorrect_Park3.xml
            XMLService.Service1Client proxy = new XMLService.Service1Client();
            string xml_url = txtXML_URL.Text;
            string xsd_url = txtSchema_URL.Text;

            lblVerifyXMLResult.Text = $"Inside of: {xml_url}\n\n" + proxy.verification(xml_url, xsd_url);
            lblVerifyXMLResult.Visible = true;
        }
    }
}