using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class FactureFournisseur_Details_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlInt32 col_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_FactureID {

			get {

				return(this.col_FactureID);
			}
			set {

				this.col_FactureID = value;
			}
		}

		internal void LoadFrom_FactureID(System.Data.SqlTypes.SqlInt32 col_FactureID, FactureFournisseur_Record parent) {
		
			if (col_FactureID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_FactureID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_FactureID = col_FactureID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte {

			get {

				return(this.col_Compte);
			}
			set {

				this.col_Compte = value;
			}
		}

		internal void LoadFrom_Compte(System.Data.SqlTypes.SqlInt32 col_Compte, Compte_Record parent) {
		
			if (col_Compte.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Compte");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Compte = col_Compte;
			this.parent = parent;
		}


		public FactureFournisseur_Details_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureFournisseur_Details'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FactureFournisseur_Details", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_Compte">[To be supplied.]</param>
		public FactureFournisseur_Details_Collection(string connectionString, System.Data.SqlTypes.SqlInt32 col_Compte) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureFournisseur_Details'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FactureFournisseur_Details", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_Compte = col_Compte;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			FactureFournisseur_Details_Record recordToAdd = record as FactureFournisseur_Details_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.FactureFournisseur_Details_Record'.", "record");
			}

			Params.spI_FactureFournisseur_Details Param = new Params.spI_FactureFournisseur_Details();
			Param.SetUpConnection(this.connectionString);

			Param.Param_FactureID = recordToAdd.Col_FactureID;
			Param.Param_Ligne = recordToAdd.Col_Ligne;
			Param.Param_Compte = recordToAdd.Col_Compte;
			Param.Param_Montant = recordToAdd.Col_Montant;
			Param.Param_RefID = recordToAdd.Col_RefID;

			SPs.spI_FactureFournisseur_Details Sp = new SPs.spI_FactureFournisseur_Details();
			if (Sp.Execute(ref Param)) {

				FactureFournisseur_Details_Record newRecord = new FactureFournisseur_Details_Record(this.connectionString, Param.Param_FactureID, Param.Param_Ligne);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureFournisseur_Details_Collection", "Add");
			}	
		}

		/// <param name="Col_FactureID">[To be supplied.]</param>
		/// <param name="Col_Ligne">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_FactureID, System.Data.SqlTypes.SqlInt32 Col_Ligne) {
		
			Params.spD_FactureFournisseur_Details Param = new Params.spD_FactureFournisseur_Details(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_FactureID = Col_FactureID;

			Param.Param_Ligne = Col_Ligne;


			SPs.spD_FactureFournisseur_Details Sp = new SPs.spD_FactureFournisseur_Details(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			FactureFournisseur_Details_Record recordToDelete = record as FactureFournisseur_Details_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.FactureFournisseur_Details_Record'.", "record");
			}

			Params.spD_FactureFournisseur_Details Param = new Params.spD_FactureFournisseur_Details(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_FactureID = recordToDelete.Col_FactureID;

			Param.Param_Ligne = recordToDelete.Col_Ligne;


			SPs.spD_FactureFournisseur_Details Sp = new SPs.spD_FactureFournisseur_Details(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_FactureFournisseur_Details_Display Param = new Params.spS_FactureFournisseur_Details_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_FactureID.IsNull) {

				Param.Param_FactureID = this.col_FactureID;
			}

			if (!this.col_Compte.IsNull) {

				Param.Param_Compte = this.col_Compte;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_FactureFournisseur_Details_Display Sp = new SPs.spS_FactureFournisseur_Details_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					FactureFournisseur_Details_Record record = new FactureFournisseur_Details_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_FactureFournisseur_Details_Display.Resultset1.Fields.Column_ID1.ColumnIndex), sqlDataReader.GetSqlInt32(SPs.spS_FactureFournisseur_Details_Display.Resultset1.Fields.Column_ID2.ColumnIndex));

					record.displayName = "spS_FactureFournisseur_Details_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureFournisseur_Details_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public FactureFournisseur_Details_Record this[int index] {

			get {
				
				return((FactureFournisseur_Details_Record)internalRecords[index]);
			}
		}

		/// <param name="col_FactureID">[To be supplied.]</param>
		/// <param name="col_Ligne">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public FactureFournisseur_Details_Record this[System.Data.SqlTypes.SqlInt32 col_FactureID, System.Data.SqlTypes.SqlInt32 col_Ligne] {

			get {

				foreach(FactureFournisseur_Details_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_FactureID == col_FactureID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_Ligne == col_Ligne).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
