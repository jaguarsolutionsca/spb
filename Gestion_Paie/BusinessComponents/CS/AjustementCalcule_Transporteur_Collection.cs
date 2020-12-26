using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class AjustementCalcule_Transporteur_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		internal void LoadFrom_AjustementID(System.Data.SqlTypes.SqlInt32 col_AjustementID, Ajustement_Transporteur_Record parent) {
		
			if (col_AjustementID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_AjustementID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_AjustementID = col_AjustementID;
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

		internal void LoadFrom_UniteID(System.Data.SqlTypes.SqlString col_UniteID, Ajustement_Transporteur_Record parent) {
		
			if (col_UniteID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_UniteID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_UniteID = col_UniteID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_MunicipaliteID {

			get {

				return(this.col_MunicipaliteID);
			}
			set {

				this.col_MunicipaliteID = value;
			}
		}

		internal void LoadFrom_MunicipaliteID(System.Data.SqlTypes.SqlString col_MunicipaliteID, Ajustement_Transporteur_Record parent) {
		
			if (col_MunicipaliteID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_MunicipaliteID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_MunicipaliteID = col_MunicipaliteID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LivraisonID {

			get {

				return(this.col_LivraisonID);
			}
			set {

				this.col_LivraisonID = value;
			}
		}

		internal void LoadFrom_LivraisonID(System.Data.SqlTypes.SqlInt32 col_LivraisonID, Livraison_Record parent) {
		
			if (col_LivraisonID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_LivraisonID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_LivraisonID = col_LivraisonID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_TransporteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TransporteurID {

			get {

				return(this.col_TransporteurID);
			}
			set {

				this.col_TransporteurID = value;
			}
		}

		internal void LoadFrom_TransporteurID(System.Data.SqlTypes.SqlString col_TransporteurID, Fournisseur_Record parent) {
		
			if (col_TransporteurID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_TransporteurID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_TransporteurID = col_TransporteurID;
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

		private System.Data.SqlTypes.SqlString col_ZoneID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ZoneID {

			get {

				return(this.col_ZoneID);
			}
			set {

				this.col_ZoneID = value;
			}
		}

		internal void LoadFrom_ZoneID(System.Data.SqlTypes.SqlString col_ZoneID, Ajustement_Transporteur_Record parent) {
		
			if (col_ZoneID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ZoneID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ZoneID = col_ZoneID;
			this.parent = parent;
		}


		public AjustementCalcule_Transporteur_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'AjustementCalcule_Transporteur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "AjustementCalcule_Transporteur", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_AjustementID">[To be supplied.]</param>
		/// <param name="col_UniteID">[To be supplied.]</param>
		/// <param name="col_MunicipaliteID">[To be supplied.]</param>
		/// <param name="col_LivraisonID">[To be supplied.]</param>
		/// <param name="col_TransporteurID">[To be supplied.]</param>
		/// <param name="col_FactureID">[To be supplied.]</param>
		/// <param name="col_ZoneID">[To be supplied.]</param>
		public AjustementCalcule_Transporteur_Collection(string connectionString, System.Data.SqlTypes.SqlInt32 col_AjustementID, System.Data.SqlTypes.SqlString col_UniteID, System.Data.SqlTypes.SqlString col_MunicipaliteID, System.Data.SqlTypes.SqlInt32 col_LivraisonID, System.Data.SqlTypes.SqlString col_TransporteurID, System.Data.SqlTypes.SqlInt32 col_FactureID, System.Data.SqlTypes.SqlString col_ZoneID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'AjustementCalcule_Transporteur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "AjustementCalcule_Transporteur", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_AjustementID = col_AjustementID;
			this.col_UniteID = col_UniteID;
			this.col_MunicipaliteID = col_MunicipaliteID;
			this.col_LivraisonID = col_LivraisonID;
			this.col_TransporteurID = col_TransporteurID;
			this.col_FactureID = col_FactureID;
			this.col_ZoneID = col_ZoneID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			AjustementCalcule_Transporteur_Record recordToAdd = record as AjustementCalcule_Transporteur_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.AjustementCalcule_Transporteur_Record'.", "record");
			}

			Params.spI_AjustementCalcule_Transporteur Param = new Params.spI_AjustementCalcule_Transporteur();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_DateCalcul = recordToAdd.Col_DateCalcul;
			Param.Param_AjustementID = recordToAdd.Col_AjustementID;
			Param.Param_UniteID = recordToAdd.Col_UniteID;
			Param.Param_MunicipaliteID = recordToAdd.Col_MunicipaliteID;
			Param.Param_LivraisonID = recordToAdd.Col_LivraisonID;
			Param.Param_TransporteurID = recordToAdd.Col_TransporteurID;
			Param.Param_Volume = recordToAdd.Col_Volume;
			Param.Param_Taux = recordToAdd.Col_Taux;
			Param.Param_Montant = recordToAdd.Col_Montant;
			Param.Param_Facture = recordToAdd.Col_Facture;
			Param.Param_FactureID = recordToAdd.Col_FactureID;
			Param.Param_ErreurCalcul = recordToAdd.Col_ErreurCalcul;
			Param.Param_ErreurDescription = recordToAdd.Col_ErreurDescription;
			Param.Param_ZoneID = recordToAdd.Col_ZoneID;

			SPs.spI_AjustementCalcule_Transporteur Sp = new SPs.spI_AjustementCalcule_Transporteur();
			if (Sp.Execute(ref Param)) {

				AjustementCalcule_Transporteur_Record newRecord = new AjustementCalcule_Transporteur_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.AjustementCalcule_Transporteur_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_AjustementCalcule_Transporteur Param = new Params.spD_AjustementCalcule_Transporteur(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_AjustementCalcule_Transporteur Sp = new SPs.spD_AjustementCalcule_Transporteur(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			AjustementCalcule_Transporteur_Record recordToDelete = record as AjustementCalcule_Transporteur_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.AjustementCalcule_Transporteur_Record'.", "record");
			}

			Params.spD_AjustementCalcule_Transporteur Param = new Params.spD_AjustementCalcule_Transporteur(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_AjustementCalcule_Transporteur Sp = new SPs.spD_AjustementCalcule_Transporteur(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_AjustementCalcule_Transporteur_Display Param = new Params.spS_AjustementCalcule_Transporteur_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_AjustementID.IsNull) {

				Param.Param_AjustementID = this.col_AjustementID;
			}

			if (!this.col_UniteID.IsNull) {

				Param.Param_UniteID = this.col_UniteID;
			}

			if (!this.col_MunicipaliteID.IsNull) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
			}

			if (!this.col_LivraisonID.IsNull) {

				Param.Param_LivraisonID = this.col_LivraisonID;
			}

			if (!this.col_TransporteurID.IsNull) {

				Param.Param_TransporteurID = this.col_TransporteurID;
			}

			if (!this.col_FactureID.IsNull) {

				Param.Param_FactureID = this.col_FactureID;
			}

			if (!this.col_ZoneID.IsNull) {

				Param.Param_ZoneID = this.col_ZoneID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_AjustementCalcule_Transporteur_Display Sp = new SPs.spS_AjustementCalcule_Transporteur_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					AjustementCalcule_Transporteur_Record record = new AjustementCalcule_Transporteur_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_AjustementCalcule_Transporteur_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_AjustementCalcule_Transporteur_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.AjustementCalcule_Transporteur_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public AjustementCalcule_Transporteur_Record this[int index] {

			get {
				
				return((AjustementCalcule_Transporteur_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public AjustementCalcule_Transporteur_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(AjustementCalcule_Transporteur_Record record in internalRecords) {

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
