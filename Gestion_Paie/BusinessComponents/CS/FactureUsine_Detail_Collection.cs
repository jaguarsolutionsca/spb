using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class FactureUsine_Detail_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlInt32 col_FactureUsineID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_FactureUsineID {

			get {

				return(this.col_FactureUsineID);
			}
			set {

				this.col_FactureUsineID = value;
			}
		}

		internal void LoadFrom_FactureUsineID(System.Data.SqlTypes.SqlInt32 col_FactureUsineID, FactureUsine_Record parent) {
		
			if (col_FactureUsineID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_FactureUsineID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_FactureUsineID = col_FactureUsineID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurID {

			get {

				return(this.col_ProducteurID);
			}
			set {

				this.col_ProducteurID = value;
			}
		}

		internal void LoadFrom_ProducteurID(System.Data.SqlTypes.SqlString col_ProducteurID, Fournisseur_Record parent) {
		
			if (col_ProducteurID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ProducteurID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ProducteurID = col_ProducteurID;
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

		private System.Data.SqlTypes.SqlString col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteMesureID {

			get {

				return(this.col_UniteMesureID);
			}
			set {

				this.col_UniteMesureID = value;
			}
		}

		internal void LoadFrom_UniteMesureID(System.Data.SqlTypes.SqlString col_UniteMesureID, UniteMesure_Record parent) {
		
			if (col_UniteMesureID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_UniteMesureID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_UniteMesureID = col_UniteMesureID;
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


		public FactureUsine_Detail_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureUsine_Detail'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FactureUsine_Detail", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_FactureUsineID">[To be supplied.]</param>
		/// <param name="col_ProducteurID">[To be supplied.]</param>
		/// <param name="col_ProducteurEntentePaiementID">[To be supplied.]</param>
		/// <param name="col_ZoneID">[To be supplied.]</param>
		/// <param name="col_MunicipaliteID">[To be supplied.]</param>
		/// <param name="col_LotID">[To be supplied.]</param>
		/// <param name="col_UniteMesureID">[To be supplied.]</param>
		/// <param name="col_LivraisonID">[To be supplied.]</param>
		/// <param name="col_EssenceID">[To be supplied.]</param>
		public FactureUsine_Detail_Collection(string connectionString, System.Data.SqlTypes.SqlInt32 col_FactureUsineID, System.Data.SqlTypes.SqlString col_ProducteurID, System.Data.SqlTypes.SqlString col_ProducteurEntentePaiementID, System.Data.SqlTypes.SqlString col_ZoneID, System.Data.SqlTypes.SqlString col_MunicipaliteID, System.Data.SqlTypes.SqlInt32 col_LotID, System.Data.SqlTypes.SqlString col_UniteMesureID, System.Data.SqlTypes.SqlInt32 col_LivraisonID, System.Data.SqlTypes.SqlString col_EssenceID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureUsine_Detail'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FactureUsine_Detail", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_FactureUsineID = col_FactureUsineID;
			this.col_ProducteurID = col_ProducteurID;
			this.col_ProducteurEntentePaiementID = col_ProducteurEntentePaiementID;
			this.col_ZoneID = col_ZoneID;
			this.col_MunicipaliteID = col_MunicipaliteID;
			this.col_LotID = col_LotID;
			this.col_UniteMesureID = col_UniteMesureID;
			this.col_LivraisonID = col_LivraisonID;
			this.col_EssenceID = col_EssenceID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			FactureUsine_Detail_Record recordToAdd = record as FactureUsine_Detail_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.FactureUsine_Detail_Record'.", "record");
			}

			Params.spI_FactureUsine_Detail Param = new Params.spI_FactureUsine_Detail();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_FactureUsineID = recordToAdd.Col_FactureUsineID;
			Param.Param_ContratID = recordToAdd.Col_ContratID;
			Param.Param_ProducteurID = recordToAdd.Col_ProducteurID;
			Param.Param_ProducteurEntentePaiementID = recordToAdd.Col_ProducteurEntentePaiementID;
			Param.Param_ZoneID = recordToAdd.Col_ZoneID;
			Param.Param_MunicipaliteID = recordToAdd.Col_MunicipaliteID;
			Param.Param_LotID = recordToAdd.Col_LotID;
			Param.Param_UniteMesureID = recordToAdd.Col_UniteMesureID;
			Param.Param_LivraisonID = recordToAdd.Col_LivraisonID;
			Param.Param_EssenceID = recordToAdd.Col_EssenceID;
			Param.Param_Code = recordToAdd.Col_Code;
			Param.Param_Volume = recordToAdd.Col_Volume;
			Param.Param_Taux = recordToAdd.Col_Taux;
			Param.Param_Montant = recordToAdd.Col_Montant;
			Param.Param_Taux_Usine_Override = recordToAdd.Col_Taux_Usine_Override;
			Param.Param_PermisID = recordToAdd.Col_PermisID;

			SPs.spI_FactureUsine_Detail Sp = new SPs.spI_FactureUsine_Detail();
			if (Sp.Execute(ref Param)) {

				FactureUsine_Detail_Record newRecord = new FactureUsine_Detail_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureUsine_Detail_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_FactureUsine_Detail Param = new Params.spD_FactureUsine_Detail(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_FactureUsine_Detail Sp = new SPs.spD_FactureUsine_Detail(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			FactureUsine_Detail_Record recordToDelete = record as FactureUsine_Detail_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.FactureUsine_Detail_Record'.", "record");
			}

			Params.spD_FactureUsine_Detail Param = new Params.spD_FactureUsine_Detail(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_FactureUsine_Detail Sp = new SPs.spD_FactureUsine_Detail(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_FactureUsine_Detail_Display Param = new Params.spS_FactureUsine_Detail_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_FactureUsineID.IsNull) {

				Param.Param_FactureUsineID = this.col_FactureUsineID;
			}

			if (!this.col_ProducteurID.IsNull) {

				Param.Param_ProducteurID = this.col_ProducteurID;
			}

			if (!this.col_ProducteurEntentePaiementID.IsNull) {

				Param.Param_ProducteurEntentePaiementID = this.col_ProducteurEntentePaiementID;
			}

			if (!this.col_ZoneID.IsNull) {

				Param.Param_ZoneID = this.col_ZoneID;
			}

			if (!this.col_MunicipaliteID.IsNull) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
			}

			if (!this.col_LotID.IsNull) {

				Param.Param_LotID = this.col_LotID;
			}

			if (!this.col_UniteMesureID.IsNull) {

				Param.Param_UniteMesureID = this.col_UniteMesureID;
			}

			if (!this.col_LivraisonID.IsNull) {

				Param.Param_LivraisonID = this.col_LivraisonID;
			}

			if (!this.col_EssenceID.IsNull) {

				Param.Param_EssenceID = this.col_EssenceID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_FactureUsine_Detail_Display Sp = new SPs.spS_FactureUsine_Detail_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					FactureUsine_Detail_Record record = new FactureUsine_Detail_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_FactureUsine_Detail_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_FactureUsine_Detail_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureUsine_Detail_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public FactureUsine_Detail_Record this[int index] {

			get {
				
				return((FactureUsine_Detail_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public FactureUsine_Detail_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(FactureUsine_Detail_Record record in internalRecords) {

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
