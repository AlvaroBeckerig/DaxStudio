﻿using System.Collections.Generic;
using System.Data;
using System.Collections;

namespace ADOTabular
{
    public class ADOTabularDatabaseCollection:IEnumerable<string>
    {
        private DataSet _dsDatabases;
        private readonly ADOTabularConnection _adoTabConn;
        public ADOTabularDatabaseCollection(ADOTabularConnection adoTabConn)
        {
            _adoTabConn = adoTabConn;
            
        }
        
        private DataTable GetDatabaseTable()
        {
            if (_dsDatabases == null)
            {
                _dsDatabases = _adoTabConn.GetSchemaDataSet("DBSCHEMA_CATALOGS");
            }
            return _dsDatabases.Tables[0];
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (DataRow dr in GetDatabaseTable().Rows)
            {
                //yield return new ADOTabularDatabase(_adoTabConn, dr["CATALOG_NAME"].ToString());//, dr);
                yield return dr["CATALOG_NAME"].ToString();//, dr);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
