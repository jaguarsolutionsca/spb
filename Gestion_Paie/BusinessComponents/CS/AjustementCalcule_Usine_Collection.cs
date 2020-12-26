using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class AjustementCalcule_Usine_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlInt32 col_AjustementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_AjustementID {

			get {

				return(this.col_AjustementID);
			}
			set {

				this.col_AjustementID = value;
			}
		}

		internal void LoadFrom_AjustementID(System.Data.SqlTypes.SqlInt32 col_AjustementID, Ajustement_EssenceUnite_Record parent) {
		
			if (col_AjustementID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_AjustementID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_AjustementID = col_AjustementID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_EssenceID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_EssenceID {

			get {

				return(this.col_EssenceID);
			}
			set {

				this.col_EssenceID = value;
			}
		}

		internal void LoadFrom_EssenceID(System.Data.SqlTypes.SqlString col_EssenceID, Ajustement_EssenceUnite_Record parent) {
		
			if (col_EssenceID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_EssenceID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_EssenceID = col_EssenceID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_UniteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteID {

			get {

				return(this.col_UniteID);
			}
			set {

				this.col_UniteID = value;
			}
		}

		internal void LoadFrom_UniteID(System.Data.SqlTypes.SqlString col_UniteID, Ajustement_EssenceUnite_Record parent) {
		
			if (col_UniteID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_UniteID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_UniteID = col_UniteID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_LivraisonDetailID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LivraisonDetailID {

			get {

				return(this.col_LivraisonDetailID);
			}
			set {

				this.col_LivraisonDetailID = value;
			}
		}

		internal void LoadFrom_LivraisonDetailID(System.Data.SqlTypes.SqlInt32 col_LivraisonDetailID, Livraison_Detail_Record parent) {
		
			if (col_LivraisonDetailID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_LivraisonDetailID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_LivraisonDetailID = col_LivraisonDetailID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_UsineID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UsineID {

			get {

				return(this.col_UsineID);
			}
			set {

				this.col_UsineID = value;
			}
		}

		internal void LoadFrom_UsineID(System.Data.SqlTypes.SqlString col_UsineID, Usine_Record parent) {
		
			if (col_UsineID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_UsineID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_UsineID = col_UsineID;
			this.parent = parent;
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

		internal void LoadFrom_FactureID(System.Data.SqlTypes.SqlInt32 col_FactureID, FactureClient_Record parent) {
		
			if (col_FactureID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_FactureID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_FactureID = col_FactureID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_Code = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Code {

			get {

				return(this.col_Code);
			}
			set {

				this.col_Code = value;
			}
		}

		internal void LoadFrom_Code(System.Data.SqlTypes.SqlString col_Code, Ajustement_EssenceUnite_Record parent) {
		
			if (col_Code.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Code");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Code = col_Code;
			this.parent = parent;
		}


		public AjustementCalcule_Usine_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'AjustementCalcule_Usine'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "AjustementCalcule_Usine", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_AjustementID">[To be supplied.]</param>
		/// <param name="col_EssenceID">[To be supplied.]</param>
		/// <param name="col_UniteID">[To be supplied.]</param>
		/// <param name="col_LivraisonDetailID">[To be supplied.]</param>
		/// <param name="col_UsineID">[To be supplied.]</param>
		/// <param name="col_FactureID">[To be supplied.]</param>
		/// <param name="col_Code">[To be supplied.]</param>
		public AjustementCalcule_Usine_Collection(string connectionString, System.Data.SqlTypes.SqlInt32 col_AjustementID, System.Data.SqlTypes.SqlString col_EssenceID, System.Data.SqlTypes.SqlString col_UniteID, System.Data.SqlTypes.SqlInt32 col_LivraisonDetailID, System.Data.SqlTypes.SqlString col_UsineID, System.Data.SqlTypes.SqlInt32 col_FactureID, System.Data.SqlTypes.SqlString col_Code) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'AjustementCalcule_Usine'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "AjustementCalcule_Usine", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_AjustementID = col_AjustementID;
			this.col_EssenceID = col_EssenceID;
			this.col_UniteID = col_UniteID;
			this.col_LivraisonDetailID = col_LivraisonDetailID;
			this.col_UsineID = col_UsineID;
			this.col_FactureID = col_FactureID;
			this.col_Code = col_Code;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			AjustementCalcule_Usine_Record recordToAdd = record as AjustementCalcule_Usine_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.AjustementCalcule_Usine_Record'.", "record");
			}

			Params.spI_AjustementCalcule_Usine Param = new Params.spI_AjustementCalcule_Usine();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_DateCalcul = recordToAdd.Col_DateCalcul;
			Param.Param_AjustementID = recordToAdd.Col_AjustementID;
			Param.Param_EssenceID = recordToAdd.Col_EssenceID;
			Param.Param_UniteID = recordToAdd.Col_UniteID;
			Param.Param_LivraisonDetailID = recordToAdd.Col_LivraisonDetailID;
			Param.Param_UsineID = recordToAdd.Col_UsineID;
			Param.Param_Volume = recordToAdd.Col_Volume;
			Param.Param_Taux = recordToAdd.Col_Taux;
			Param.Param_Montant = recordToAdd.Col_Montant;
			Param.Param_Facture = recordToAdd.Col_Facture;
			Param.Param_FactureID = recordToAdd.Col_FactureID;
			Param.Param_ErreurCalcul = recordToAdd.Col_ErreurCalcul;
			Param.Param_ErreurDescription = recordToAdd.Col_ErreurDescription;
			Param.Param_Code = recordToAdd.Col_Code;

			SPs.spI_AjustementCalcule_Usine Sp = new SPs.spI_AjustementCalcule_Usine();
			if (Sp.Execute(ref Param)) {

				AjustementCalcule_Usine_Record newRecord = new AjustementCalcule_Usine_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.AjustementCalcule_Usine_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_AjustementCalcule_Usine Param = new Params.spD_AjustementCalcule_Usine(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_AjustementCalcule_Usine Sp = new SPs.spD_AjustementCalcule_Usine(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			AjustementCalcule_Usine_Record recordToDelete = record as AjustementCalcule_Usine_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.AjustementCalcule_Usine_Record'.", "record");
			}

			Params.spD_AjustementCalcule_Usine Param = new Params.spD_AjustementCalcule_Usine(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_AjustementCalcule_Usine Sp = new SPs.spD_AjustementCalcule_Usine(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_AjustementCalcule_Usine_Display Param = new Params.spS_AjustementCalcule_Usine_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_AjustementID.IsNull) {

				Param.Param_AjustementID = this.col_AjustementID;
			}

			if (!this.col_EssenceID.IsNull) {

				Param.Param_EssenceID = this.col_EssenceID;
			}

			if (!this.col_UniteID.IsNull) {

				Param.Param_UniteID = this.col_UniteID;
			}

			if (!this.col_LivraisonDetailID.IsNull) {

				Param.Param_LivraisonDetailID = this.col_LivraisonDetailID;
			}

			if (!this.col_UsineID.IsNull) {

				Param.Param_UsineID = this.col_UsineID;
			}

			if (!this.col_FactureID.IsNull) {

				Param.Param_FactureID = this.col_FactureID;
			}

			if (!this.col_Code.IsNull) {

				Param.Param_Code = this.col_Code;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_AjustementCalcule_Usine_Display Sp = new SPs.spS_AjustementCalcule_Usine_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					AjustementCalcule_Usine_Record record = new AjustementCalcule_Usine_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_AjustementCalcule_Usine_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_AjustementCalcule_Usine_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.AjustementCalcule_Usine_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public AjustementCalcule_Usine_Record this[int index] {

			get {
				
				return((AjustementCalcule_Usine_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public AjustementCalcule_Usine_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(AjustementCalcule_Usine_Record record in internalRecords) {

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
