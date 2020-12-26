using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Cert_Proprietaire_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlString col_FournisseurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_FournisseurID {

			get {

				return(this.col_FournisseurID);
			}
			set {

				this.col_FournisseurID = value;
			}
		}

		internal void LoadFrom_FournisseurID(System.Data.SqlTypes.SqlString col_FournisseurID, Fournisseur_Record parent) {
		
			if (col_FournisseurID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_FournisseurID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_FournisseurID = col_FournisseurID;
			this.parent = parent;
		}


		public Cert_Proprietaire_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Cert_Proprietaire'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Cert_Proprietaire", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_FournisseurID">[To be supplied.]</param>
		public Cert_Proprietaire_Collection(string connectionString, System.Data.SqlTypes.SqlString col_FournisseurID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Cert_Proprietaire'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Cert_Proprietaire", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_FournisseurID = col_FournisseurID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Cert_Proprietaire_Record recordToAdd = record as Cert_Proprietaire_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Cert_Proprietaire_Record'.", "record");
			}

			Params.spI_Cert_Proprietaire Param = new Params.spI_Cert_Proprietaire();
			Param.SetUpConnection(this.connectionString);

			Param.Param_Agence = recordToAdd.Col_Agence;
			Param.Param_NO_ACT = recordToAdd.Col_NO_ACT;
			Param.Param_Nom = recordToAdd.Col_Nom;
			Param.Param_Representant = recordToAdd.Col_Representant;
			Param.Param_ADRESSE = recordToAdd.Col_ADRESSE;
			Param.Param_Ville = recordToAdd.Col_Ville;
			Param.Param_CODE_POST = recordToAdd.Col_CODE_POST;
			Param.Param_TEL_RES = recordToAdd.Col_TEL_RES;
			Param.Param_TEL_BUR = recordToAdd.Col_TEL_BUR;
			Param.Param_FournisseurID = recordToAdd.Col_FournisseurID;
			Param.Param_FournisseurNom = recordToAdd.Col_FournisseurNom;
			Param.Param_Traite = recordToAdd.Col_Traite;
			Param.Param_Methode = recordToAdd.Col_Methode;

			SPs.spI_Cert_Proprietaire Sp = new SPs.spI_Cert_Proprietaire();
			if (Sp.Execute(ref Param)) {

				Cert_Proprietaire_Record newRecord = new Cert_Proprietaire_Record(this.connectionString, Param.Param_Agence, Param.Param_NO_ACT);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Cert_Proprietaire_Collection", "Add");
			}	
		}

		/// <param name="Col_Agence">[To be supplied.]</param>
		/// <param name="Col_NO_ACT">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlString Col_Agence, System.Data.SqlTypes.SqlString Col_NO_ACT) {
		
			Params.spD_Cert_Proprietaire Param = new Params.spD_Cert_Proprietaire(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_Agence = Col_Agence;

			Param.Param_NO_ACT = Col_NO_ACT;


			SPs.spD_Cert_Proprietaire Sp = new SPs.spD_Cert_Proprietaire(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Cert_Proprietaire_Record recordToDelete = record as Cert_Proprietaire_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Cert_Proprietaire_Record'.", "record");
			}

			Params.spD_Cert_Proprietaire Param = new Params.spD_Cert_Proprietaire(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_Agence = recordToDelete.Col_Agence;

			Param.Param_NO_ACT = recordToDelete.Col_NO_ACT;


			SPs.spD_Cert_Proprietaire Sp = new SPs.spD_Cert_Proprietaire(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Cert_Proprietaire_Display Param = new Params.spS_Cert_Proprietaire_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_FournisseurID.IsNull) {

				Param.Param_FournisseurID = this.col_FournisseurID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Cert_Proprietaire_Display Sp = new SPs.spS_Cert_Proprietaire_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Cert_Proprietaire_Record record = new Cert_Proprietaire_Record(this.connectionString, sqlDataReader.GetSqlString(SPs.spS_Cert_Proprietaire_Display.Resultset1.Fields.Column_ID1.ColumnIndex), sqlDataReader.GetSqlString(SPs.spS_Cert_Proprietaire_Display.Resultset1.Fields.Column_ID2.ColumnIndex));

					record.displayName = "spS_Cert_Proprietaire_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Cert_Proprietaire_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Cert_Proprietaire_Record this[int index] {

			get {
				
				return((Cert_Proprietaire_Record)internalRecords[index]);
			}
		}

		/// <param name="col_Agence">[To be supplied.]</param>
		/// <param name="col_NO_ACT">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Cert_Proprietaire_Record this[System.Data.SqlTypes.SqlString col_Agence, System.Data.SqlTypes.SqlString col_NO_ACT] {

			get {

				foreach(Cert_Proprietaire_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_Agence == col_Agence).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_NO_ACT == col_NO_ACT).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
