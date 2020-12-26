using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class FactureClient_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

		private System.Collections.ArrayList internalRecords;
		private bool recordsAreLoaded = false;

		private IBusinessComponentRecord parent = null;
		public IBusinessComponentRecord Parent {

			get {

				return(parent);
			}
		}

		public bool ContainsListCollection {

			get {

				return(true);
			}
		}

		public System.Collections.IList GetList() {

			return(internalRecords);
		}

		public int Count {

			get {

				if (!this.recordsAreLoaded) {

					Refresh();
				}

				return(internalRecords.Count);
			}
		}

		private string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}

		private System.Data.SqlTypes.SqlString col_TypeFacture = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TypeFacture {

			get {

				return(this.col_TypeFacture);
			}
			set {

				this.col_TypeFacture = value;
			}
		}

		internal void LoadFrom_TypeFacture(System.Data.SqlTypes.SqlString col_TypeFacture, TypeFacture_Record parent) {
		
			if (col_TypeFacture.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_TypeFacture");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_TypeFacture = col_TypeFacture;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_TypeInvoiceClientAcomba = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_TypeInvoiceClientAcomba {

			get {

				return(this.col_TypeInvoiceClientAcomba);
			}
			set {

				this.col_TypeInvoiceClientAcomba = value;
			}
		}

		internal void LoadFrom_TypeInvoiceClientAcomba(System.Data.SqlTypes.SqlInt32 col_TypeInvoiceClientAcomba, TypeInvoiceClientAcomba_Record parent) {
		
			if (col_TypeInvoiceClientAcomba.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_TypeInvoiceClientAcomba");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_TypeInvoiceClientAcomba = col_TypeInvoiceClientAcomba;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_ClientID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ClientID {

			get {

				return(this.col_ClientID);
			}
			set {

				this.col_ClientID = value;
			}
		}

		internal void LoadFrom_ClientID(System.Data.SqlTypes.SqlString col_ClientID, Usine_Record parent) {
		
			if (col_ClientID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ClientID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ClientID = col_ClientID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_PayerAID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_PayerAID {

			get {

				return(this.col_PayerAID);
			}
			set {

				this.col_PayerAID = value;
			}
		}

		internal void LoadFrom_PayerAID(System.Data.SqlTypes.SqlString col_PayerAID, Usine_Record parent) {
		
			if (col_PayerAID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_PayerAID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_PayerAID = col_PayerAID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_Status = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Status {

			get {

				return(this.col_Status);
			}
			set {

				this.col_Status = value;
			}
		}

		internal void LoadFrom_Status(System.Data.SqlTypes.SqlString col_Status, FactureStatus_Record parent) {
		
			if (col_Status.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Status");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Status = col_Status;
			this.parent = parent;
		}


		public FactureClient_Collection(string connectionString) {
			
			this.connectionString = connectionString;

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

			string DebugConnectionString = connectionString;

			if (DebugConnectionString == System.String.Empty) {

				DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
			}

			if (DebugConnectionString == System.String.Empty) {

				DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
			}

			if (DebugConnectionString != String.Empty) {

				System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

				sqlConnection.Open();

				System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureClient'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FactureClient", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_TypeFacture">[To be supplied.]</param>
		/// <param name="col_TypeInvoiceClientAcomba">[To be supplied.]</param>
		/// <param name="col_ClientID">[To be supplied.]</param>
		/// <param name="col_PayerAID">[To be supplied.]</param>
		/// <param name="col_Status">[To be supplied.]</param>
		public FactureClient_Collection(string connectionString, System.Data.SqlTypes.SqlString col_TypeFacture, System.Data.SqlTypes.SqlInt32 col_TypeInvoiceClientAcomba, System.Data.SqlTypes.SqlString col_ClientID, System.Data.SqlTypes.SqlString col_PayerAID, System.Data.SqlTypes.SqlString col_Status) {
			
			this.connectionString = connectionString;

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

			string DebugConnectionString = connectionString;

			if (DebugConnectionString == System.String.Empty) {

				DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
			}

			if (DebugConnectionString == System.String.Empty) {

				DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
			}

			if (DebugConnectionString != String.Empty) {

				System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

				sqlConnection.Open();

				System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureClient'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FactureClient", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_TypeFacture = col_TypeFacture;
			this.col_TypeInvoiceClientAcomba = col_TypeInvoiceClientAcomba;
			this.col_ClientID = col_ClientID;
			this.col_PayerAID = col_PayerAID;
			this.col_Status = col_Status;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			FactureClient_Record recordToAdd = record as FactureClient_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.FactureClient_Record'.", "record");
			}

			Params.spI_FactureClient Param = new Params.spI_FactureClient();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_NoFacture = recordToAdd.Col_NoFacture;
			Param.Param_DateFacture = recordToAdd.Col_DateFacture;
			Param.Param_Annee = recordToAdd.Col_Annee;
			Param.Param_TypeFacture = recordToAdd.Col_TypeFacture;
			Param.Param_TypeInvoiceClientAcomba = recordToAdd.Col_TypeInvoiceClientAcomba;
			Param.Param_ClientID = recordToAdd.Col_ClientID;
			Param.Param_PayerAID = recordToAdd.Col_PayerAID;
			Param.Param_Montant_Total = recordToAdd.Col_Montant_Total;
			Param.Param_Montant_TPS = recordToAdd.Col_Montant_TPS;
			Param.Param_Montant_TVQ = recordToAdd.Col_Montant_TVQ;
			Param.Param_Description = recordToAdd.Col_Description;
			Param.Param_Status = recordToAdd.Col_Status;
			Param.Param_StatusDescription = recordToAdd.Col_StatusDescription;
			Param.Param_DateFactureAcomba = recordToAdd.Col_DateFactureAcomba;

			SPs.spI_FactureClient Sp = new SPs.spI_FactureClient();
			if (Sp.Execute(ref Param)) {

				FactureClient_Record newRecord = new FactureClient_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureClient_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_FactureClient Param = new Params.spD_FactureClient(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_FactureClient Sp = new SPs.spD_FactureClient(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			FactureClient_Record recordToDelete = record as FactureClient_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.FactureClient_Record'.", "record");
			}

			Params.spD_FactureClient Param = new Params.spD_FactureClient(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_FactureClient Sp = new SPs.spD_FactureClient(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_FactureClient_Display Param = new Params.spS_FactureClient_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_TypeFacture.IsNull) {

				Param.Param_TypeFacture = this.col_TypeFacture;
			}

			if (!this.col_TypeInvoiceClientAcomba.IsNull) {

				Param.Param_TypeInvoiceClientAcomba = this.col_TypeInvoiceClientAcomba;
			}

			if (!this.col_ClientID.IsNull) {

				Param.Param_ClientID = this.col_ClientID;
			}

			if (!this.col_PayerAID.IsNull) {

				Param.Param_PayerAID = this.col_PayerAID;
			}

			if (!this.col_Status.IsNull) {

				Param.Param_Status = this.col_Status;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_FactureClient_Display Sp = new SPs.spS_FactureClient_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					FactureClient_Record record = new FactureClient_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_FactureClient_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_FactureClient_Display";

					internalRecords.Add(record);
				}

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				this.recordsAreLoaded = true;
			}
			else {

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				this.recordsAreLoaded = false;
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureClient_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public FactureClient_Record this[int index] {

			get {
				
				return((FactureClient_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public FactureClient_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(FactureClient_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_ID == col_ID).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
