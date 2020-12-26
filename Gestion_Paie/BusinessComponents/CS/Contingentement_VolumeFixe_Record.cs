using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Contingentement_VolumeFixe] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Contingentement_VolumeFixe_Collection"/> class to do so.
	/// </summary>
	public sealed class Contingentement_VolumeFixe_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Contingentement_VolumeFixe_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Contingentement_VolumeFixe_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Contingentement_VolumeFixe_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ContingentementID">[To be supplied.]</param>
		/// <param name="col_Superficie_Min">[To be supplied.]</param>
		public Contingentement_VolumeFixe_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ContingentementID, System.Data.SqlTypes.SqlSingle col_Superficie_Min) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement_VolumeFixe'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contingentement_VolumeFixe", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ContingentementID = col_ContingentementID;
			this.col_Superficie_Min = col_Superficie_Min;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ContingentementID {
		
			get {
			
				return(this.col_ContingentementID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ContingentementID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlSingle col_Superficie_Min = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Superficie_Min {
		
			get {
			
				return(this.col_Superficie_Min);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_Superficie_Min = value;
				}
			}
		}
		
		
		private Contingentement_Record col_ContingentementID_Record = null;
		public Contingentement_Record Col_ContingentementID_Contingentement_Record {
		
			get {

				if (this.col_ContingentementID_Record == null) {
				
					this.col_ContingentementID_Record = new Contingentement_Record(this.connectionString, this.col_ContingentementID);
				}
				
				return(this.col_ContingentementID_Record);
			}
		}

		internal bool col_Volume_FixeWasSet = false;
		private bool col_Volume_FixeWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Volume_Fixe = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Volume_Fixe {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume_Fixe);
			}
			set {
			
				this.col_Volume_FixeWasUpdated = true;
				this.col_Volume_FixeWasSet = true;
				this.col_Volume_Fixe = value;
			}
		}

		internal bool col_NombreMoisWasSet = false;
		private bool col_NombreMoisWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_NombreMois = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_NombreMois {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NombreMois);
			}
			set {
			
				this.col_NombreMoisWasUpdated = true;
				this.col_NombreMoisWasSet = true;
				this.col_NombreMois = value;
			}
		}

		internal bool col_UseNombreMoisWasSet = false;
		private bool col_UseNombreMoisWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_UseNombreMois = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_UseNombreMois {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UseNombreMois);
			}
			set {
			
				this.col_UseNombreMoisWasUpdated = true;
				this.col_UseNombreMoisWasSet = true;
				this.col_UseNombreMois = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;


			this.col_Volume_FixeWasUpdated = false;
			this.col_Volume_FixeWasSet = false;
			this.col_Volume_Fixe = System.Data.SqlTypes.SqlSingle.Null;

			this.col_NombreMoisWasUpdated = false;
			this.col_NombreMoisWasSet = false;
			this.col_NombreMois = System.Data.SqlTypes.SqlInt32.Null;

			this.col_UseNombreMoisWasUpdated = false;
			this.col_UseNombreMoisWasSet = false;
			this.col_UseNombreMois = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Contingentement_VolumeFixe Param = new Params.spS_Contingentement_VolumeFixe(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ContingentementID.IsNull) {

				Param.Param_ContingentementID = this.col_ContingentementID;
			}

			if (!this.col_Superficie_Min.IsNull) {

				Param.Param_Superficie_Min = this.col_Superficie_Min;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Contingentement_VolumeFixe Sp = new SPs.spS_Contingentement_VolumeFixe();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_VolumeFixe.Resultset1.Fields.Column_Volume_Fixe.ColumnIndex)) {

						this.col_Volume_Fixe = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement_VolumeFixe.Resultset1.Fields.Column_Volume_Fixe.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_VolumeFixe.Resultset1.Fields.Column_NombreMois.ColumnIndex)) {

						this.col_NombreMois = sqlDataReader.GetSqlInt32(SPs.spS_Contingentement_VolumeFixe.Resultset1.Fields.Column_NombreMois.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_VolumeFixe.Resultset1.Fields.Column_UseNombreMois.ColumnIndex)) {

						this.col_UseNombreMois = sqlDataReader.GetSqlBoolean(SPs.spS_Contingentement_VolumeFixe.Resultset1.Fields.Column_UseNombreMois.ColumnIndex);
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = true;

					return(true);
				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = false;

					return(false);
				}
			}
			else {

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_VolumeFixe_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Volume_FixeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NombreMoisWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UseNombreMoisWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Contingentement_VolumeFixe Param = new Params.spU_Contingentement_VolumeFixe(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ContingentementID = this.col_ContingentementID;
			Param.Param_Superficie_Min = this.col_Superficie_Min;

			if (this.col_Volume_FixeWasUpdated) {

				Param.Param_Volume_Fixe = this.col_Volume_Fixe;
				Param.Param_ConsiderNull_Volume_Fixe = true;
			}

			if (this.col_NombreMoisWasUpdated) {

				Param.Param_NombreMois = this.col_NombreMois;
				Param.Param_ConsiderNull_NombreMois = true;
			}

			if (this.col_UseNombreMoisWasUpdated) {

				Param.Param_UseNombreMois = this.col_UseNombreMois;
				Param.Param_ConsiderNull_UseNombreMois = true;
			}

			SPs.spU_Contingentement_VolumeFixe Sp = new SPs.spU_Contingentement_VolumeFixe();
			if (Sp.Execute(ref Param)) {

				this.col_Volume_FixeWasUpdated = false;
				this.col_NombreMoisWasUpdated = false;
				this.col_UseNombreMoisWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_VolumeFixe_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Contingentement_VolumeFixe_Display Param = new Params.spS_Contingentement_VolumeFixe_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ContingentementID = this.col_ContingentementID;
				Param.Param_Superficie_Min = this.col_Superficie_Min;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Contingentement_VolumeFixe_Display Sp = new SPs.spS_Contingentement_VolumeFixe_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_VolumeFixe_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Contingentement_VolumeFixe_Display";
						}
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_VolumeFixe_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
