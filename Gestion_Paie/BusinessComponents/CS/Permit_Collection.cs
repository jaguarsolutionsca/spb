using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Permit_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlString col_ContratID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ContratID {

			get {

				return(this.col_ContratID);
			}
			set {

				this.col_ContratID = value;
			}
		}

		internal void LoadFrom_ContratID(System.Data.SqlTypes.SqlString col_ContratID, Contrat_Record parent) {
		
			if (col_ContratID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ContratID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ContratID = col_ContratID;
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

		internal void LoadFrom_EssenceID(System.Data.SqlTypes.SqlString col_EssenceID, Essence_Record parent) {
		
			if (col_EssenceID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_EssenceID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_EssenceID = col_EssenceID;
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

		private System.Data.SqlTypes.SqlString col_ProducteurDroitCoupeID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurDroitCoupeID {

			get {

				return(this.col_ProducteurDroitCoupeID);
			}
			set {

				this.col_ProducteurDroitCoupeID = value;
			}
		}

		internal void LoadFrom_ProducteurDroitCoupeID(System.Data.SqlTypes.SqlString col_ProducteurDroitCoupeID, Fournisseur_Record parent) {
		
			if (col_ProducteurDroitCoupeID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ProducteurDroitCoupeID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ProducteurDroitCoupeID = col_ProducteurDroitCoupeID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_ProducteurEntentePaiementID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurEntentePaiementID {

			get {

				return(this.col_ProducteurEntentePaiementID);
			}
			set {

				this.col_ProducteurEntentePaiementID = value;
			}
		}

		internal void LoadFrom_ProducteurEntentePaiementID(System.Data.SqlTypes.SqlString col_ProducteurEntentePaiementID, Fournisseur_Record parent) {
		
			if (col_ProducteurEntentePaiementID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ProducteurEntentePaiementID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ProducteurEntentePaiementID = col_ProducteurEntentePaiementID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_LotID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LotID {

			get {

				return(this.col_LotID);
			}
			set {

				this.col_LotID = value;
			}
		}

		internal void LoadFrom_LotID(System.Data.SqlTypes.SqlInt32 col_LotID, Lot_Record parent) {
		
			if (col_LotID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_LotID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_LotID = col_LotID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_ChargeurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ChargeurID {

			get {

				return(this.col_ChargeurID);
			}
			set {

				this.col_ChargeurID = value;
			}
		}

		internal void LoadFrom_ChargeurID(System.Data.SqlTypes.SqlString col_ChargeurID, Fournisseur_Record parent) {
		
			if (col_ChargeurID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ChargeurID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ChargeurID = col_ChargeurID;
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

		internal void LoadFrom_ZoneID(System.Data.SqlTypes.SqlString col_ZoneID, Municipalite_Zone_Record parent) {
		
			if (col_ZoneID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ZoneID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ZoneID = col_ZoneID;
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

		internal void LoadFrom_MunicipaliteID(System.Data.SqlTypes.SqlString col_MunicipaliteID, Municipalite_Zone_Record parent) {
		
			if (col_MunicipaliteID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_MunicipaliteID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_MunicipaliteID = col_MunicipaliteID;
			this.parent = parent;
		}


		public Permit_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Permit'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Permit", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_ContratID">[To be supplied.]</param>
		/// <param name="col_EssenceID">[To be supplied.]</param>
		/// <param name="col_TransporteurID">[To be supplied.]</param>
		/// <param name="col_ProducteurDroitCoupeID">[To be supplied.]</param>
		/// <param name="col_ProducteurEntentePaiementID">[To be supplied.]</param>
		/// <param name="col_LotID">[To be supplied.]</param>
		/// <param name="col_ChargeurID">[To be supplied.]</param>
		/// <param name="col_ZoneID">[To be supplied.]</param>
		/// <param name="col_MunicipaliteID">[To be supplied.]</param>
		public Permit_Collection(string connectionString, System.Data.SqlTypes.SqlString col_ContratID, System.Data.SqlTypes.SqlString col_EssenceID, System.Data.SqlTypes.SqlString col_TransporteurID, System.Data.SqlTypes.SqlString col_ProducteurDroitCoupeID, System.Data.SqlTypes.SqlString col_ProducteurEntentePaiementID, System.Data.SqlTypes.SqlInt32 col_LotID, System.Data.SqlTypes.SqlString col_ChargeurID, System.Data.SqlTypes.SqlString col_ZoneID, System.Data.SqlTypes.SqlString col_MunicipaliteID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Permit'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Permit", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_ContratID = col_ContratID;
			this.col_EssenceID = col_EssenceID;
			this.col_TransporteurID = col_TransporteurID;
			this.col_ProducteurDroitCoupeID = col_ProducteurDroitCoupeID;
			this.col_ProducteurEntentePaiementID = col_ProducteurEntentePaiementID;
			this.col_LotID = col_LotID;
			this.col_ChargeurID = col_ChargeurID;
			this.col_ZoneID = col_ZoneID;
			this.col_MunicipaliteID = col_MunicipaliteID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Permit_Record recordToAdd = record as Permit_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Permit_Record'.", "record");
			}

			Params.spI_Permit Param = new Params.spI_Permit();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_DatePermit = recordToAdd.Col_DatePermit;
			Param.Param_DateDebut = recordToAdd.Col_DateDebut;
			Param.Param_DateFin = recordToAdd.Col_DateFin;
			Param.Param_Annee = recordToAdd.Col_Annee;
			Param.Param_Periode = recordToAdd.Col_Periode;
			Param.Param_ContratID = recordToAdd.Col_ContratID;
			Param.Param_EssenceID = recordToAdd.Col_EssenceID;
			Param.Param_PermitSciage = recordToAdd.Col_PermitSciage;
			Param.Param_TransporteurID = recordToAdd.Col_TransporteurID;
			Param.Param_VR = recordToAdd.Col_VR;
			Param.Param_ProducteurDroitCoupeID = recordToAdd.Col_ProducteurDroitCoupeID;
			Param.Param_ProducteurEntentePaiementID = recordToAdd.Col_ProducteurEntentePaiementID;
			Param.Param_PermitLivre = recordToAdd.Col_PermitLivre;
			Param.Param_PermitImprime = recordToAdd.Col_PermitImprime;
			Param.Param_PermitAnnule = recordToAdd.Col_PermitAnnule;
			Param.Param_LotID = recordToAdd.Col_LotID;
			Param.Param_EssenceSciage = recordToAdd.Col_EssenceSciage;
			Param.Param_Code = recordToAdd.Col_Code;
			Param.Param_Remarques = recordToAdd.Col_Remarques;
			Param.Param_ChargeurID = recordToAdd.Col_ChargeurID;
			Param.Param_ZoneID = recordToAdd.Col_ZoneID;
			Param.Param_MunicipaliteID = recordToAdd.Col_MunicipaliteID;

			SPs.spI_Permit Sp = new SPs.spI_Permit();
			if (Sp.Execute(ref Param)) {

				Permit_Record newRecord = new Permit_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Permit_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_Permit Param = new Params.spD_Permit(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_Permit Sp = new SPs.spD_Permit(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Permit_Record recordToDelete = record as Permit_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Permit_Record'.", "record");
			}

			Params.spD_Permit Param = new Params.spD_Permit(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_Permit Sp = new SPs.spD_Permit(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Permit_Display Param = new Params.spS_Permit_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ContratID.IsNull) {

				Param.Param_ContratID = this.col_ContratID;
			}

			if (!this.col_EssenceID.IsNull) {

				Param.Param_EssenceID = this.col_EssenceID;
			}

			if (!this.col_TransporteurID.IsNull) {

				Param.Param_TransporteurID = this.col_TransporteurID;
			}

			if (!this.col_ProducteurDroitCoupeID.IsNull) {

				Param.Param_ProducteurDroitCoupeID = this.col_ProducteurDroitCoupeID;
			}

			if (!this.col_ProducteurEntentePaiementID.IsNull) {

				Param.Param_ProducteurEntentePaiementID = this.col_ProducteurEntentePaiementID;
			}

			if (!this.col_LotID.IsNull) {

				Param.Param_LotID = this.col_LotID;
			}

			if (!this.col_ChargeurID.IsNull) {

				Param.Param_ChargeurID = this.col_ChargeurID;
			}

			if (!this.col_ZoneID.IsNull) {

				Param.Param_ZoneID = this.col_ZoneID;
			}

			if (!this.col_MunicipaliteID.IsNull) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Permit_Display Sp = new SPs.spS_Permit_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Permit_Record record = new Permit_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_Permit_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_Permit_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Permit_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Permit_Record this[int index] {

			get {
				
				return((Permit_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Permit_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(Permit_Record record in internalRecords) {

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
