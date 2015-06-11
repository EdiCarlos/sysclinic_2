using SysClinic.Dal.AuthorizationDal;
using SysClinic.Dto.AuthorizationDto;
using System.Linq;
using System.Net.NetworkInformation;

namespace SysClinic.Bll
{
    public class MacBll
    {
        MacDal macDal;
        MacDto macDto;

        public MacBll()
        {
            macDal = new MacDal();
            macDto = new MacDto();


        }
        public string PegarEnderecoMAc()
        {
            return (from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                           ).FirstOrDefault().Replace(":", "");
        }
        public MacDto GetMac()
        {
            return macDal.GetMac();
        }

        public void AlteraMac(MacDto macDto)
        {
            macDal.AlteraMac(macDto);
        }


    }
}
