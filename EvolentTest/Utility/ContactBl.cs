using EvolentTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EvolentTest.Utility
{
    public class ContactBl
    {

        public int SaveContactDetails(Contact contactModel)
        {
            List<SqlParameter> sqlParamters = new List<SqlParameter>()
                {

                                         new SqlParameter() { ParameterName = "@FirstName", SqlDbType = SqlDbType.NVarChar, Value = contactModel.FirstName },
                                         new SqlParameter() { ParameterName = "@LastName", SqlDbType = SqlDbType.NVarChar, Value = contactModel.LastName },
                                         new SqlParameter() { ParameterName = "@Email", SqlDbType = SqlDbType.NVarChar, Value = contactModel.Email},
                                         new SqlParameter() { ParameterName = "@PhoneNumber", SqlDbType = SqlDbType.NVarChar, Value = contactModel.Phone },
                                         new SqlParameter() { ParameterName = "@Status", SqlDbType = SqlDbType.NVarChar, Value = contactModel.Status },
                                         new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.NVarChar, Value = contactModel.Id },
            };
            return SqlFunctions.ExecuteNonQuery("SaveUserContactDetails", sqlParamters);
        }

        public List<Contact> GetContactList()
        {
            List<Contact> contactDetails = new List<Contact>();


            DataSet dsContactDetails = new DataSet();


            dsContactDetails = SqlFunctions.ExecuteDataSet("GetContactDetails", null);
            if (dsContactDetails != null && dsContactDetails.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dsContactDetails.Tables[0].Rows)
                {
                    Contact contactInformation = new Contact();
                    contactInformation.FirstName = Convert.ToString(row["FirstName"]);
                    contactInformation.LastName = Convert.ToString(row["LastName"]);
                    contactInformation.Phone = Convert.ToString(row["PhoneNumber"]);
                    contactInformation.Email = Convert.ToString(row["Email"]);
                    contactInformation.Status = Convert.ToBoolean(row["Status"]);
                    contactInformation.Id = Convert.ToString(row["Id"]);

                    contactDetails.Add(contactInformation);
                }
            }


            return contactDetails;
        }

        public Contact GetContactInformation(int id)
        {
            Contact contactInformation = new Contact();
            DataSet dsContactDetails = new DataSet();
            List<SqlParameter> sqlParamters = new List<SqlParameter>()
                {

                                        new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.NVarChar, Value = id },
                                     
            };

            dsContactDetails = SqlFunctions.ExecuteDataSet("GetContactInformation", sqlParamters);

            if (dsContactDetails != null && dsContactDetails.Tables[0].Rows.Count > 0)
            {


                foreach (DataRow row in dsContactDetails.Tables[0].Rows)
                {
                   
                    contactInformation.FirstName = Convert.ToString(row["FirstName"]);
                    contactInformation.LastName = Convert.ToString(row["LastName"]);
                    contactInformation.Phone = Convert.ToString(row["PhoneNumber"]);
                    contactInformation.Email = Convert.ToString(row["Email"]);
                    contactInformation.Status = Convert.ToBoolean(row["Status"]);
                    contactInformation.Id = Convert.ToString(row["Id"]);

                    
                }


            }
            return contactInformation;
        }

        public int DeleteContactInformation(int id)
        {
            List<SqlParameter> sqlParamters = new List<SqlParameter>()
                {

                                         new SqlParameter() { ParameterName = "@Id", SqlDbType = SqlDbType.NVarChar, Value = id },
            };
            return SqlFunctions.ExecuteNonQuery("DeleteContactInformation", sqlParamters);
        }
            }
}