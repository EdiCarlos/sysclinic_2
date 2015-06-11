using SysClinic.Dto.AuthorizationDto;
using SysClinic.Resource.Resources;
using SysGestor.DAL.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysClinic.Dal.AuthorizationDal
{
    public class MacDal
    {
        public MacDto GetMac()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT chave, empresa, cnpj" +
                                      "FROM analise";             

                SqlDataReader dr = Conexao.Buscar(comando);
                
                MacDto macDto = new MacDto();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        macDto.Chave = Convert.ToString(Convert.IsDBNull(dr["chave"]) ? null : dr["chave"]);
                        macDto.Empresa = Convert.ToString(Convert.IsDBNull(dr["empresa"]) ? null : dr["empresa"]);
                        macDto.Cnpj = Convert.ToString(Convert.IsDBNull(dr["cnpj"]) ? null : dr["cnpj"]);
                    }                                        
                }
                return macDto;
            }
            catch (Exception ex)
            {
                throw new Exception(Errors.SelectDataErrors + " - " + ex.Message);
            }
        }
        
        public void AlteraMac(MacDto macDto)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "UPDATE analise SET chave = @Chave, empresa = @Empresa, cnpj = @Cnpj " +
                                      "WHERE idConfig = @IdConfig";

                comando.Parameters.AddWithValue("@Chave", macDto.Chave);
                comando.Parameters.AddWithValue("@Empresa", macDto.Empresa);
                comando.Parameters.AddWithValue("@Cnpj", macDto.Cnpj);
                comando.Parameters.AddWithValue("@IdConfig", 1);

                Conexao.Crud(comando);
            }
            catch (Exception ex)
            {
                throw new Exception(Errors.UpdateDataErrors + " - " + ex.Message);
            }
        }
    }
}
