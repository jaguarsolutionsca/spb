using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Lot_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlString col_CantonID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_CantonID {

			get {

				return(this.col_CantonID);
			}
			set {

				this.col_CantonID = value;
			}
		}

		internal void LoadFrom_CantonID(System.Data.SqlTypes.SqlString col_CantonID, Canton_Record parent) {
		
			if (col_CantonID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_CantonID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_CantonID = col_CantonID;
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

		private System.Data.SqlTypes.SqlString col_ProprietaireID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProprietaireID {

			get {

				return(this.col_ProprietaireID);
			}
			set {

				this.col_ProprietaireID = value;
			}
		}

		internal void LoadFrom_ProprietaireID(System.Data.SqlTypes.SqlString col_ProprietaireID, Fournisseur_Record parent) {
		
			if (col_ProprietaireID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ProprietaireID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ProprietaireID = col_ProprietaireID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_ContingentID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ContingentID {

			get {

				return(this.col_ContingentID);
			}
			set {

				this.col_ContingentID = value;
			}
		}

		internal void LoadFrom_ContingentID(System.Data.SqlTypes.SqlString col_ContingentID, Fournisseur_Record parent) {
		
			if (col_ContingentID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ContingentID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ContingentID = col_ContingentID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_Droit_coupeID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Droit_coupeID {

			get {

				return(this.col_Droit_coupeID);
			}
			set {

				this.col_Droit_coupeID = value;
			}
		}

		internal void LoadFrom_Droit_coupeID(System.Data.SqlTypes.SqlString col_Droit_coupeID, Fournisseur_Record parent) {
		
			if (col_Droit_coupeID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Droit_coupeID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Droit_coupeID = col_Droit_coupeID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_Entente_paiementID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Entente_paiementID {

			get {

				return(this.col_Entente_paiementID);
			}
			set {

				this.col_Entente_paiementID = value;
			}
		}

		internal void LoadFrom_Entente_paiementID(System.Data.SqlTypes.SqlString col_Entente_paiementID, Fournisseur_Record parent) {
		
			if (col_Entente_paiementID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Entente_paiementID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Entente_paiementID = col_Entente_paiementID;
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


		public Lot_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Lot'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Lot", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_CantonID">[To be supplied.]</param>
		/// <param name="col_MunicipaliteID">[To be supplied.]</param>
		/// <param name="col_ProprietaireID">[To be supplied.]</param>
		/// <param name="col_ContingentID">[To be supplied.]</param>
		/// <param name="col_Droit_coupeID">[To be supplied.]</param>
		/// <param name="col_Entente_paiementID">[To be supplied.]</param>
		/// <param name="col_ZoneID">[To be supplied.]</param>
		public Lot_Collection(string connectionString, System.Data.SqlTypes.SqlString col_CantonID, System.Data.SqlTypes.SqlString col_MunicipaliteID, System.Data.SqlTypes.SqlString col_ProprietaireID, System.Data.SqlTypes.SqlString col_ContingentID, System.Data.SqlTypes.SqlString col_Droit_coupeID, System.Data.SqlTypes.SqlString col_Entente_paiementID, System.Data.SqlTypes.SqlString col_ZoneID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Lot'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Lot", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_CantonID = col_CantonID;
			this.col_MunicipaliteID = col_MunicipaliteID;
			this.col_ProprietaireID = col_ProprietaireID;
			this.col_ContingentID = col_ContingentID;
			this.col_Droit_coupeID = col_Droit_coupeID;
			this.col_Entente_paiementID = col_Entente_paiementID;
			this.col_ZoneID = col_ZoneID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Lot_Record recordToAdd = record as Lot_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Lot_Record'.", "record");
			}

			Params.spI_Lot Param = new Params.spI_Lot();
			Param.SetUpConnection(this.connectionString);

			Param.Param_CantonID = recordToAdd.Col_CantonID;
			Param.Param_Rang = recordToAdd.Col_Rang;
			Param.Param_Lot = recordToAdd.Col_Lot;
			Param.Param_MunicipaliteID = recordToAdd.Col_MunicipaliteID;
			Param.Param_Superficie_total = recordToAdd.Col_Superficie_total;
			Param.Param_Superficie_boisee = recordToAdd.Col_Superficie_boisee;
			Param.Param_ProprietaireID = recordToAdd.Col_ProprietaireID;
			Param.Param_ContingentID = recordToAdd.Col_ContingentID;
			Param.Param_Contingent_Date = recordToAdd.Col_Contingent_Date;
			Param.Param_Droit_coupeID = recordToAdd.Col_Droit_coupeID;
			Param.Param_Droit_coupe_Date = recordToAdd.Col_Droit_coupe_Date;
			Param.Param_Entente_paiementID = recordToAdd.Col_Entente_paiementID;
			Param.Param_Entente_paiement_Date = recordToAdd.Col_Entente_paiement_Date;
			Param.Param_Actif = recordToAdd.Col_Actif;
			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_Sequence = recordToAdd.Col_Sequence;
			Param.Param_Partie = recordToAdd.Col_Partie;
			Param.Param_Matricule = recordToAdd.Col_Matricule;
			Param.Param_ZoneID = recordToAdd.Col_ZoneID;
			Param.Param_Secteur = recordToAdd.Col_Secteur;
			Param.Param_Cadastre = recordToAdd.Col_Cadastre;
			Param.Param_Reforme = recordToAdd.Col_Reforme;
			Param.Param_LotsComplementaires = recordToAdd.Col_LotsComplementaires;
			Param.Param_Certifie = recordToAdd.Col_Certifie;
			Param.Param_NumeroCertification = recordToAdd.Col_NumeroCertification;
			Param.Param_OGC = recordToAdd.Col_OGC;

			SPs.spI_Lot Sp = new SPs.spI_Lot();
			if (Sp.Execute(ref Param)) {

				Lot_Record newRecord = new Lot_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Lot_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_Lot Param = new Params.spD_Lot(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_Lot Sp = new SPs.spD_Lot(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Lot_Record recordToDelete = record as Lot_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Lot_Record'.", "record");
			}

			Params.spD_Lot Param = new Params.spD_Lot(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_Lot Sp = new SPs.spD_Lot(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Lot_Display Param = new Params.spS_Lot_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_CantonID.IsNull) {

				Param.Param_CantonID = this.col_CantonID;
			}

			if (!this.col_MunicipaliteID.IsNull) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
			}

			if (!this.col_ProprietaireID.IsNull) {

				Param.Param_ProprietaireID = this.col_ProprietaireID;
			}

			if (!this.col_ContingentID.IsNull) {

				Param.Param_ContingentID = this.col_ContingentID;
			}

			if (!this.col_Droit_coupeID.IsNull) {

				Param.Param_Droit_coupeID = this.col_Droit_coupeID;
			}

			if (!this.col_Entente_paiementID.IsNull) {

				Param.Param_Entente_paiementID = this.col_Entente_paiementID;
			}

			if (!this.col_ZoneID.IsNull) {

				Param.Param_ZoneID = this.col_ZoneID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Lot_Display Sp = new SPs.spS_Lot_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Lot_Record record = new Lot_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_Lot_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_Lot_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Lot_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Lot_Record this[int index] {

			get {
				
				return((Lot_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Lot_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(Lot_Record record in internalRecords) {

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
