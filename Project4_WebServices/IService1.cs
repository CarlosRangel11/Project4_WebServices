using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml;

namespace Project4_XMLServices {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1 {
        // Takes in a Park object to work "seamlessly" as a service op
        // Creates a new park object and uses xml tools to fill up the local xml file. 
        [OperationContract]
        void addPark(Park park);

        // takes in a string representing a url to check if a remote xml file 
        // conforms to the local xml schema inside of app_data
        [OperationContract]
        Task<string> verification(string xml_url, string xsd_url);

        // This service is not required, but makes my life easier in the gui
        [OperationContract]
        string GetXMLDoc();

    }


    // Used to transport all the data (it's a lot lmao)
    /* Below is the information that we need to fill inside of the remote xml file: 
     XML TEMPLATE: 
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

    [DataContract]
    public class Park {
        string park_Type;
        string owner;
        string name;

        string reservation_Address;
        string reservation_Url;

        string[] neighboring_States;
        string established_In;
        string founder;

        [DataMember]
        public string Park_Type { get; set; }
        [DataMember]
        public string Owner { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Reservation_Address { get; set; }
        [DataMember]
        public string Reservation_Url { get; set; }
        [DataMember]
        public string[] Neighboring_States { get; set; }
        [DataMember]
        public string Established_In { get; set; }
        [DataMember]
        public string Founder { get; set; }
    }

}
