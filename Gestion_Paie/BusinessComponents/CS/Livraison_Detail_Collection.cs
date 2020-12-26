using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Livraison_Detail_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlString col_ContratID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ContratID {

			get {

				return(this.col_ContratID);
			}
			set {

				this.col_ContratID = value;
			}
		}

		internal void LoadFrom_ContratID(System.Data.SqlTypes.SqlString col_ContratID, Contrat_EssenceUnite_Record parent) {
		
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

		internal void LoadFrom_EssenceID(System.Data.SqlTypes.SqlString col_EssenceID, Contrat_EssenceUnite_Record parent) {
		
			if (col_EssenceID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_EssenceID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_EssenceID = col_EssenceID;
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

		internal void LoadFrom_UniteMesureID(System.Data.SqlTypes.SqlString col_UniteMesureID, Contrat_EssenceUnite_Record parent) {
		
			if (col_UniteMesureID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_UniteMesureID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_UniteMesureID = col_UniteMesureID;
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

		private System.Data.SqlTypes.SqlInt32 col_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ContingentementID {

			get {

				return(this.col_ContingentementID);
			}
			set {

				this.col_ContingentementID = value;
			}
		}

		internal void LoadFrom_ContingentementID(System.Data.SqlTypes.SqlInt32 col_ContingentementID, Contingentement_Record parent) {
		
			if (col_ContingentementID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ContingentementID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ContingentementID = col_ContingentementID;
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

		internal void LoadFrom_Code(System.Data.SqlTypes.SqlString col_Code, Contrat_EssenceUnite_Record parent) {
		
			if (col_Code.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Code");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Code = col_Code;
			this.parent = parent;
		}


		public Livraison_Detail_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Livraison_Detail'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Livraison_Detail", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_LivraisonID">[To be supplied.]</param>
		/// <param name="col_ContratID">[To be supplied.]</param>
		/// <param name="col_EssenceID">[To be supplied.]</param>
		/// <param name="col_UniteMesureID">[To be supplied.]</param>
		/// <param name="col_ProducteurID">[To be supplied.]</param>
		/// <param name="col_ContingentementID">[To be supplied.]</param>
		/// <param name="col_Code">[To be supplied.]</param>
		public Livraison_Detail_Collection(string connectionString, System.Data.SqlTypes.SqlInt32 col_LivraisonID, System.Data.SqlTypes.SqlString col_ContratID, System.Data.SqlTypes.SqlString col_EssenceID, System.Data.SqlTypes.SqlString col_UniteMesureID, System.Data.SqlTypes.SqlString col_ProducteurID, System.Data.SqlTypes.SqlInt32 col_ContingentementID, System.Data.SqlTypes.SqlString col_Code) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Livraison_Detail'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Livraison_Detail", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_LivraisonID = col_LivraisonID;
			this.col_ContratID = col_ContratID;
			this.col_EssenceID = col_EssenceID;
			this.col_UniteMesureID = col_UniteMesureID;
			this.col_ProducteurID = col_ProducteurID;
			this.col_ContingentementID = col_ContingentementID;
			this.col_Code = col_Code;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Livraison_Detail_Record recordToAdd = record as Livraison_Detail_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Livraison_Detail_Record'.", "record");
			}

			Params.spI_Livraison_Detail Param = new Params.spI_Livraison_Detail();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_LivraisonID = recordToAdd.Col_LivraisonID;
			Param.Param_ContratID = recordToAdd.Col_ContratID;
			Param.Param_EssenceID = recordToAdd.Col_EssenceID;
			Param.Param_UniteMesureID = recordToAdd.Col_UniteMesureID;
			Param.Param_ProducteurID = recordToAdd.Col_ProducteurID;
			Param.Param_Droit_Coupe = recordToAdd.Col_Droit_Coupe;
			Param.Param_VolumeBrut = recordToAdd.Col_VolumeBrut;
			Param.Param_VolumeReduction = recordToAdd.Col_VolumeReduction;
			Param.Param_VolumeNet = recordToAdd.Col_VolumeNet;
			Param.Param_VolumeContingente = recordToAdd.Col_VolumeContingente;
			Param.Param_ContingentementID = recordToAdd.Col_ContingentementID;
			Param.Param_DateCalcul = recordToAdd.Col_DateCalcul;
			Param.Param_Taux_Usine = recordToAdd.Col_Taux_Usine;
			Param.Param_Montant_Usine = recordToAdd.Col_Montant_Usine;
			Param.Param_Taux_Producteur = recordToAdd.Col_Taux_Producteur;
			Param.Param_Montant_ProducteurBrut = recordToAdd.Col_Montant_ProducteurBrut;
			Param.Param_Taux_TransporteurMoyen = recordToAdd.Col_Taux_TransporteurMoyen;
			Param.Param_Taux_TransporteurMoyen_Override = recordToAdd.Col_Taux_TransporteurMoyen_Override;
			Param.Param_Montant_TransporteurMoyen = recordToAdd.Col_Montant_TransporteurMoyen;
			Param.Param_Taux_Preleve_Plan_Conjoint = recordToAdd.Col_Taux_Preleve_Plan_Conjoint;
			Param.Param_Montant_Preleve_Plan_Conjoint = recordToAdd.Col_Montant_Preleve_Plan_Conjoint;
			Param.Param_Taux_Preleve_Fond_Roulement = recordToAdd.Col_Taux_Preleve_Fond_Roulement;
			Param.Param_Montant_Preleve_Fond_Roulement = recordToAdd.Col_Montant_Preleve_Fond_Roulement;
			Param.Param_Taux_Preleve_Fond_Forestier = recordToAdd.Col_Taux_Preleve_Fond_Forestier;
			Param.Param_Montant_Preleve_Fond_Forestier = recordToAdd.Col_Montant_Preleve_Fond_Forestier;
			Param.Param_Taux_Preleve_Divers = recordToAdd.Col_Taux_Preleve_Divers;
			Param.Param_Montant_Preleve_Divers = recordToAdd.Col_Montant_Preleve_Divers;
			Param.Param_Montant_ProducteurNet = recordToAdd.Col_Montant_ProducteurNet;
			Param.Param_Taux_Producteur_Override = recordToAdd.Col_Taux_Producteur_Override;
			Param.Param_Taux_Usine_Override = recordToAdd.Col_Taux_Usine_Override;
			Param.Param_Code = recordToAdd.Col_Code;
			Param.Param_UsePreleveMontant = recordToAdd.Col_UsePreleveMontant;

			SPs.spI_Livraison_Detail Sp = new SPs.spI_Livraison_Detail();
			if (Sp.Execute(ref Param)) {

				Livraison_Detail_Record newRecord = new Livraison_Detail_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Detail_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_Livraison_Detail Param = new Params.spD_Livraison_Detail(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_Livraison_Detail Sp = new SPs.spD_Livraison_Detail(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Livraison_Detail_Record recordToDelete = record as Livraison_Detail_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Livraison_Detail_Record'.", "record");
			}

			Params.spD_Livraison_Detail Param = new Params.spD_Livraison_Detail(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_Livraison_Detail Sp = new SPs.spD_Livraison_Detail(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Livraison_Detail_Display Param = new Params.spS_Livraison_Detail_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_LivraisonID.IsNull) {

				Param.Param_LivraisonID = this.col_LivraisonID;
			}

			if (!this.col_ContratID.IsNull) {

				Param.Param_ContratID = this.col_ContratID;
			}

			if (!this.col_EssenceID.IsNull) {

				Param.Param_EssenceID = this.col_EssenceID;
			}

			if (!this.col_UniteMesureID.IsNull) {

				Param.Param_UniteMesureID = this.col_UniteMesureID;
			}

			if (!this.col_ProducteurID.IsNull) {

				Param.Param_ProducteurID = this.col_ProducteurID;
			}

			if (!this.col_ContingentementID.IsNull) {

				Param.Param_ContingentementID = this.col_ContingentementID;
			}

			if (!this.col_Code.IsNull) {

				Param.Param_Code = this.col_Code;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Livraison_Detail_Display Sp = new SPs.spS_Livraison_Detail_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Livraison_Detail_Record record = new Livraison_Detail_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_Livraison_Detail_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_Livraison_Detail_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Detail_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Livraison_Detail_Record this[int index] {

			get {
				
				return((Livraison_Detail_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Livraison_Detail_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(Livraison_Detail_Record record in internalRecords) {

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
