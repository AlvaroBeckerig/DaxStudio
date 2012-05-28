﻿namespace ADOTabular
{
    public class ADOTabularDatabase
    {
        private readonly ADOTabularConnection _adoTabConn;
        private readonly string _databaseName;
        private ADOTabularModelCollection _modelColl;

        public ADOTabularDatabase(ADOTabularConnection adoTabConn, string databaseName)
        {
            _adoTabConn = adoTabConn;
            _databaseName = databaseName;
        }

        public string Name
        {
            get { return _databaseName; }
        }

        public ADOTabularModelCollection Models
        {
            get { return _modelColl ?? (_modelColl = new ADOTabularModelCollection(_adoTabConn, this)); }
        }

        public ADOTabularConnection Connection
        {
            get { return _adoTabConn; }
        }
    }
}
