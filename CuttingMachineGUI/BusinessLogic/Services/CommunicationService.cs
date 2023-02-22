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


    #region INPUTS
    //TODO: addresses To be de defined
    public enum cylinderInput : ushort
    {

        T_US_Rotate_HP = 0,
        T_US_Rotate_WP = 0,
        Axis_Y_Wheels_HP = 0,
        Axis_Y_Wheels_WP = 0,

        treader_Z_HP = 0,
        treader_Z_WP = 0,

        Cuthead_tool_HP = 0,
        Cuthead_tool_WP = 0,
        T_US_Axis_Z_HP = 0,
        T_US_Axis_Z_WP = 0,

        Presser_Y_HP = 0,
        Presser_Y_WP = 0,

        Gripper_Close_HP = 0,
        Gripper_Open_WP = 0,

        Clamp_Load_HP = 0,
        Clamp_Load_WP = 0
    }



    public enum PresenceSensor : ushort
    {
        Cuthead = 0,
        first = 0,
        second = 0,
        third = 0,
        forth = 0,
        Cloth_roll = 0,
        Air_Pressure = 0
    }

    public enum Button : ushort
    {
        Emergency_Stop = 0,
        Restart = 0,
        second = 0,
    }

    #endregion

    #region OUTPUTS


    public enum cylinderOutput : ushort
    {
        T_US_Rotate_Backward = 0,
        T_US_Rotate_Forward = 0,
        Axis_Y_Wheels_Upward = 0,
        Axis_Y_Wheels_Downward = 0,

        treader_Z_Upward = 0,
        treader_Z_Downward = 0,

        Cuthead_tool_Out = 0,
        Cuthead_tool_In = 0,

        T_US_Axis_Z = 0, // upwards and downwards
        Presser_Y = 0, //upwards and downwards

        Gripper = 0, //close and open

        Clamp_Load = 0,//downwards and upwards
    }

    public enum Turret : ushort
    {
        Green = 0,
        Red = 0,
        Ambar = 0,
        Buzzer = 0,

    }





    #endregion



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
                return _modbusMaster.ReadHoldingRegisters(1, address, 1)[0];
            });
        }

        public async Task WriteMemory(ushort address, ushort value)
        {
            await Task.Run(() =>
            {
                _modbusMaster.WriteSingleRegister(1, address, value);
            });
        }
    }
}
