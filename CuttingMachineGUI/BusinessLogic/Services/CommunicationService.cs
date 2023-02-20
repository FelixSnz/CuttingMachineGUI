using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;

namespace CuttingMachineGUI.BusinessLogic.Services
{

    public interface IPlcCommunication
    {
        Task<ushort> ReadMemory(ushort address);
        Task WriteMemory(ushort address, ushort value);
    }
    public class PlcCommunicationService : IPlcCommunication
    {
        private readonly IPAddress _ipAddress;
        private readonly int _port;
        private readonly ModbusIpMaster _modbusMaster;

        public PlcCommunicationService(string ipAddress, int port)
        {
            _ipAddress = IPAddress.Parse(ipAddress);
            _port = port;
            _modbusMaster = ModbusIpMaster.CreateIp(new TcpClient(ipAddress, port));
        }

        public async Task<ushort> ReadMemory(ushort address)
        {
            return await Task.Run(() =>
            {
                return _modbusMaster.ReadHoldingRegisters(0, address, 1)[0];
            });
        }

        public async Task WriteMemory(ushort address, ushort value)
        {
            await Task.Run(() =>
            {
                _modbusMaster.WriteSingleRegister(0, address, value);
            });
        }
    }
}
