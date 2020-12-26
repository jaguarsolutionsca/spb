using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Contingentement_Producteur_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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


		public Contingentement_Producteur_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement_Producteur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contingentement_Producteur", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Contingentement_Producteur_Record recordToAdd = record as Contingentement_Producteur_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Contingentement_Producteur_Record'.", "record");
			}

			Params.spI_Contingentement_Producteur Param = new Params.spI_Contingentement_Producteur();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ContingentementID = recordToAdd.Col_ContingentementID;
			Param.Param_ProducteurID = recordToAdd.Col_ProducteurID;
			Param.Param_Superficie_Contingentee = recordToAdd.Col_Superficie_Contingentee;
			Param.Param_Volume_Demande = recordToAdd.Col_Volume_Demande;
			Param.Param_Volume_Facteur = recordToAdd.Col_Volume_Facteur;
			Param.Param_Volume_Fixe = recordToAdd.Col_Volume_Fixe;
			Param.Param_Volume_Supplementaire = recordToAdd.Col_Volume_Supplementaire;
			Param.Param_Volume_Accorde = recordToAdd.Col_Volume_Accorde;
			Param.Param_Date_Modification = recordToAdd.Col_Date_Modification;
			Param.Param_Volume_Inventaire = recordToAdd.Col_Volume_Inventaire;
			Param.Param_LastLivraison = recordToAdd.Col_LastLivraison;
			Param.Param_VolumeMaximum = recordToAdd.Col_VolumeMaximum;
			Param.Param_Imprime = recordToAdd.Col_Imprime;

			SPs.spI_Contingentement_Producteur Sp = new SPs.spI_Contingentement_Producteur();
			if (Sp.Execute(ref Param)) {

				Contingentement_Producteur_Record newRecord = new Contingentement_Producteur_Record(this.connectionString, Param.Param_ContingentementID, Param.Param_ProducteurID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Producteur_Collection", "Add");
			}	
		}

		/// <param name="Col_ContingentementID">[To be supplied.]</param>
		/// <param name="Col_ProducteurID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ContingentementID, System.Data.SqlTypes.SqlString Col_ProducteurID) {
		
			Params.spD_Contingentement_Producteur Param = new Params.spD_Contingentement_Producteur(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ContingentementID = Col_ContingentementID;

			Param.Param_ProducteurID = Col_ProducteurID;


			SPs.spD_Contingentement_Producteur Sp = new SPs.spD_Contingentement_Producteur(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Contingentement_Producteur_Record recordToDelete = record as Contingentement_Producteur_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Contingentement_Producteur_Record'.", "record");
			}

			Params.spD_Contingentement_Producteur Param = new Params.spD_Contingentement_Producteur(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ContingentementID = recordToDelete.Col_ContingentementID;

			Param.Param_ProducteurID = recordToDelete.Col_ProducteurID;


			SPs.spD_Contingentement_Producteur Sp = new SPs.spD_Contingentement_Producteur(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Contingentement_Producteur_Display Param = new Params.spS_Contingentement_Producteur_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ContingentementID.IsNull) {

				Param.Param_ContingentementID = this.col_ContingentementID;
			}

			if (!this.col_ProducteurID.IsNull) {

				Param.Param_ProducteurID = this.col_ProducteurID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Contingentement_Producteur_Display Sp = new SPs.spS_Contingentement_Producteur_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Contingentement_Producteur_Record record = new Contingentement_Producteur_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_Contingentement_Producteur_Display.Resultset1.Fields.Column_ID1.ColumnIndex), sqlDataReader.GetSqlString(SPs.spS_Contingentement_Producteur_Display.Resultset1.Fields.Column_ID2.ColumnIndex));

					record.displayName = "spS_Contingentement_Producteur_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Producteur_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Contingentement_Producteur_Record this[int index] {

			get {
				
				return((Contingentement_Producteur_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ContingentementID">[To be supplied.]</param>
		/// <param name="col_ProducteurID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Contingentement_Producteur_Record this[System.Data.SqlTypes.SqlInt32 col_ContingentementID, System.Data.SqlTypes.SqlString col_ProducteurID] {

			get {

				foreach(Contingentement_Producteur_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_ContingentementID == col_ContingentementID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_ProducteurID == col_ProducteurID).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
