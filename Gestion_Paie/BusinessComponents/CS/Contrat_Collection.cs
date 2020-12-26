using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Contrat_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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


		public Contrat_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contrat'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contrat", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_UsineID">[To be supplied.]</param>
		public Contrat_Collection(string connectionString, System.Data.SqlTypes.SqlString col_UsineID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contrat'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contrat", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_UsineID = col_UsineID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Contrat_Record recordToAdd = record as Contrat_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Contrat_Record'.", "record");
			}

			Params.spI_Contrat Param = new Params.spI_Contrat();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_Description = recordToAdd.Col_Description;
			Param.Param_UsineID = recordToAdd.Col_UsineID;
			Param.Param_Annee = recordToAdd.Col_Annee;
			Param.Param_Date_debut = recordToAdd.Col_Date_debut;
			Param.Param_Date_fin = recordToAdd.Col_Date_fin;
			Param.Param_Actif = recordToAdd.Col_Actif;
			Param.Param_PaieTransporteur = recordToAdd.Col_PaieTransporteur;
			Param.Param_Taux_Surcharge = recordToAdd.Col_Taux_Surcharge;
			Param.Param_SurchargeManuel = recordToAdd.Col_SurchargeManuel;
			Param.Param_TxTransSameProd = recordToAdd.Col_TxTransSameProd;

			SPs.spI_Contrat Sp = new SPs.spI_Contrat();
			if (Sp.Execute(ref Param)) {

				Contrat_Record newRecord = new Contrat_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contrat_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlString Col_ID) {
		
			Params.spD_Contrat Param = new Params.spD_Contrat(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_Contrat Sp = new SPs.spD_Contrat(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Contrat_Record recordToDelete = record as Contrat_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Contrat_Record'.", "record");
			}

			Params.spD_Contrat Param = new Params.spD_Contrat(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_Contrat Sp = new SPs.spD_Contrat(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Contrat_Display Param = new Params.spS_Contrat_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_UsineID.IsNull) {

				Param.Param_UsineID = this.col_UsineID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Contrat_Display Sp = new SPs.spS_Contrat_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Contrat_Record record = new Contrat_Record(this.connectionString, sqlDataReader.GetSqlString(SPs.spS_Contrat_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_Contrat_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contrat_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Contrat_Record this[int index] {

			get {
				
				return((Contrat_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Contrat_Record this[System.Data.SqlTypes.SqlString col_ID] {

			get {

				foreach(Contrat_Record record in internalRecords) {

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
