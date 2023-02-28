using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sres.Net.EEIP;

namespace CuttingMachineGUI.BusinessLogic.Services
{
    internal class EEIPService
    {
        //A private field to store the EEIPClient instance
        private EEIPClient eeipClient;

        //A constructor that takes the IP address and port of the PLC as parameters
        public EEIPService(string ipAddress, ushort port = 44818)
        {
            //Create a new instance of the EEIPClient object
            eeipClient = new EEIPClient();

            //Register a Session using the given IP address and port
            eeipClient.RegisterSession(ipAddress, port);
        }

        //A method to read an array of bytes from a given address of the PLC
        public byte[] ReadData(int instanceId, int classId, int attributeId)
        {
            //Read an array of bytes from Instance (instanceId) and Attribute (attributeId) of Class (classId)
            byte[] data = eeipClient.GetAttributeSingle(instanceId, classId, attributeId);

            //Return the data
            return data;
        }

        //A method to write an array of bytes to a given address of the PLC
        public void WriteData(byte[] data, int instanceId, int classId, int attributeId)
        {
            //Write an array of bytes to Instance (instanceId) and Attribute (attributeId) of Class (classId)
            eeipClient.SetAttributeSingle(instanceId, classId, attributeId, data);
        }

        //A method to close the connection with the PLC
        public void Close()
        {
            //Forward Close the connection
            eeipClient.ForwardClose();

            //UnRegister Session
            eeipClient.UnRegisterSession();
        }
    }
}
