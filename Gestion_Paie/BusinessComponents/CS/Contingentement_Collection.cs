using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Contingentement_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlInt32 col_RegroupementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_RegroupementID {

			get {

				return(this.col_RegroupementID);
			}
			set {

				this.col_RegroupementID = value;
			}
		}

		internal void LoadFrom_RegroupementID(System.Data.SqlTypes.SqlInt32 col_RegroupementID, EssenceRegroupement_Record parent) {
		
			if (col_RegroupementID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_RegroupementID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_RegroupementID = col_RegroupementID;
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


		public Contingentement_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contingentement", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_UsineID">[To be supplied.]</param>
		/// <param name="col_RegroupementID">[To be supplied.]</param>
		/// <param name="col_EssenceID">[To be supplied.]</param>
		/// <param name="col_UniteMesureID">[To be supplied.]</param>
		public Contingentement_Collection(string connectionString, System.Data.SqlTypes.SqlString col_UsineID, System.Data.SqlTypes.SqlInt32 col_RegroupementID, System.Data.SqlTypes.SqlString col_EssenceID, System.Data.SqlTypes.SqlString col_UniteMesureID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contingentement", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_UsineID = col_UsineID;
			this.col_RegroupementID = col_RegroupementID;
			this.col_EssenceID = col_EssenceID;
			this.col_UniteMesureID = col_UniteMesureID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Contingentement_Record recordToAdd = record as Contingentement_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Contingentement_Record'.", "record");
			}

			Params.spI_Contingentement Param = new Params.spI_Contingentement();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_ContingentUsine = recordToAdd.Col_ContingentUsine;
			Param.Param_UsineID = recordToAdd.Col_UsineID;
			Param.Param_RegroupementID = recordToAdd.Col_RegroupementID;
			Param.Param_Annee = recordToAdd.Col_Annee;
			Param.Param_PeriodeContingentement = recordToAdd.Col_PeriodeContingentement;
			Param.Param_PeriodeDebut = recordToAdd.Col_PeriodeDebut;
			Param.Param_PeriodeFin = recordToAdd.Col_PeriodeFin;
			Param.Param_EssenceID = recordToAdd.Col_EssenceID;
			Param.Param_UniteMesureID = recordToAdd.Col_UniteMesureID;
			Param.Param_Volume_Usine = recordToAdd.Col_Volume_Usine;
			Param.Param_Facteur = recordToAdd.Col_Facteur;
			Param.Param_Volume_Fixe = recordToAdd.Col_Volume_Fixe;
			Param.Param_Date_Calcul = recordToAdd.Col_Date_Calcul;
			Param.Param_CalculAccepte = recordToAdd.Col_CalculAccepte;
			Param.Param_Code = recordToAdd.Col_Code;
			Param.Param_Volume_Regroupement = recordToAdd.Col_Volume_Regroupement;
			Param.Param_Volume_RegroupementPourcentage = recordToAdd.Col_Volume_RegroupementPourcentage;
			Param.Param_MaxVolumeFixe_Pourcentage = recordToAdd.Col_MaxVolumeFixe_Pourcentage;
			Param.Param_MaxVolumeFixe_ContingentementID = recordToAdd.Col_MaxVolumeFixe_ContingentementID;
			Param.Param_UseVolumeFixeUnique = recordToAdd.Col_UseVolumeFixeUnique;
			Param.Param_MasseContingentVoyageDefaut = recordToAdd.Col_MasseContingentVoyageDefaut;

			SPs.spI_Contingentement Sp = new SPs.spI_Contingentement();
			if (Sp.Execute(ref Param)) {

				Contingentement_Record newRecord = new Contingentement_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_Contingentement Param = new Params.spD_Contingentement(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_Contingentement Sp = new SPs.spD_Contingentement(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Contingentement_Record recordToDelete = record as Contingentement_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Contingentement_Record'.", "record");
			}

			Params.spD_Contingentement Param = new Params.spD_Contingentement(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_Contingentement Sp = new SPs.spD_Contingentement(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Contingentement_Display Param = new Params.spS_Contingentement_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_UsineID.IsNull) {

				Param.Param_UsineID = this.col_UsineID;
			}

			if (!this.col_RegroupementID.IsNull) {

				Param.Param_RegroupementID = this.col_RegroupementID;
			}

			if (!this.col_EssenceID.IsNull) {

				Param.Param_EssenceID = this.col_EssenceID;
			}

			if (!this.col_UniteMesureID.IsNull) {

				Param.Param_UniteMesureID = this.col_UniteMesureID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Contingentement_Display Sp = new SPs.spS_Contingentement_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Contingentement_Record record = new Contingentement_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_Contingentement_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_Contingentement_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Contingentement_Record this[int index] {

			get {
				
				return((Contingentement_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Contingentement_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(Contingentement_Record record in internalRecords) {

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
