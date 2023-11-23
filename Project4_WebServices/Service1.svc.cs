using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Project4_XMLServices {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1 {
        private static readonly string XML_Url = "https://www.public.asu.edu/~carange4/Parks.xml";
        private static readonly string Schema_Url = "https://www.public.asu.edu/~carange4/Parks.xsd";
        private static readonly string localXML_Path = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Parks.xml");
        private static HttpClient httpClient;

        public async void addPark(Park park) {
            // First retrieve the original XML file from a website. 
            using (httpClient = new HttpClient()) {
                string xml_string = await httpClient.GetStringAsync(XML_Url);
                XDocument xd = XDocument.Parse(xml_string);

                // Second, modify the XML file to add a new park (to the end)
                // we will add a new park, which will be under \Parks\complexType\sequence tags

                /*XML TEMPLATE: 
                    <Park type="">
                        <Owner></Owner>
                        <Name></Name>
                        <Reservation>
                            <Address></Address>
                            <Url></Url>
                        </Reservation>

                        <Neighboring_States></Neighboring_States>
                        <Established_In></Established_In>
                    </Park>                                             */
                XNamespace ns = Schema_Url;
                XElement parentToParks = xd.Root;
                if (parentToParks != null) {
                    parentToParks.Add(
                        new XElement(ns + "Park",
                            new XAttribute("type", park.Park_Type),
                            new XElement(ns + "Owner", park.Owner),
                            new XElement(ns + "Name", park.Name),
                            new XElement(ns + "Reservation",
                                new XElement(ns + "Address", park.Reservation_Address),
                                new XElement(ns + "Url", park.Reservation_Url)
                            ),
                            new XElement(ns + "Neighboring_States", park.Neighboring_States),
                            new XElement(ns + "Established_In", park.Established_In)
                        )
                    );
                }


                // Lastly, save the modified file into App_Data. 
                xd.Save(localXML_Path);
            }
        }

        public async Task<string> verification(string xml_url, string xsd_url) {

            // First load in both the xml to be verified and the schema
            try {
                using (httpClient = new HttpClient()) {
                    // Get Xml doc
                    string xml = await httpClient.GetStringAsync(xml_url);
                    XDocument xmlDoc = XDocument.Parse(xml);

                    // Get schema doc
                    string schema = await httpClient.GetStringAsync(xsd_url);
                    XmlSchemaSet schemaSet = new XmlSchemaSet();

                    // Parse the schema and add it to the global _schemas list. 
                    using (TextReader reader = new StringReader(schema)) {
                        XmlSchema localSchema = XmlSchema.Read(reader, null);
                        schemaSet.Add(localSchema);
                    }

                    // validate the xml doc with the newly gathered schema and return 
                    // either "No Error" or a string with the error. 
                    string result = "No Error";
                    xmlDoc.Validate(schemaSet, (unused, e) => {
                        result = e.Message;
                    });

                    // Return constructed result string
                    return result;
                }


            // Catching any errors inside the http operations. 
            } catch (Exception ex){
                return $"ERROR: inside verification => {ex.Message}";
            }
        }

        //quick method for use in the gui. has to be string because of serialization issue??
        public string GetXMLDoc() {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(localXML_Path);
            return xmlDoc.OuterXml;
        }
    }
}
