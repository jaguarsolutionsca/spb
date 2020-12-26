using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [GestionVolume_Detail] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.GestionVolume_Detail_Collection"/> class to do so.
	/// </summary>
	public sealed class GestionVolume_Detail_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the GestionVolume_Detail_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.GestionVolume_Detail_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public GestionVolume_Detail_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public GestionVolume_Detail_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'GestionVolume_Detail'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "GestionVolume_Detail", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ID = col_ID;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_ID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ID {
		
			get {
			
				return(this.col_ID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ID = value;
				}
			}
		}
		
		internal bool col_GestionVolumeIDWasSet = false;
		private bool col_GestionVolumeIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_GestionVolumeID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_GestionVolumeID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_GestionVolumeID);
			}
			set {
			
				this.col_GestionVolumeIDWasUpdated = true;
				this.col_GestionVolumeIDWasSet = true;
				this.col_GestionVolumeID_Record = null;
				this.col_GestionVolumeID = value;
			}
		}

		
		private GestionVolume_Record col_GestionVolumeID_Record = null;
		public GestionVolume_Record Col_GestionVolumeID_GestionVolume_Record {
		
			get {

				if (this.col_GestionVolumeID_Record == null) {
				
					this.col_GestionVolumeID_Record = new GestionVolume_Record(this.connectionString, this.col_GestionVolumeID);
				}
				
				return(this.col_GestionVolumeID_Record);
			}
		}

		internal bool col_EssenceIDWasSet = false;
		private bool col_EssenceIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_EssenceID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_EssenceID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_EssenceID);
			}
			set {
			
				this.col_EssenceIDWasUpdated = true;
				this.col_EssenceIDWasSet = true;
				this.col_EssenceID_Record = null;
				this.col_EssenceID = value;
			}
		}

		
		private Essence_Unite_Record col_EssenceID_Record = null;
		public Essence_Unite_Record Col_EssenceID_Essence_Unite_Record {
		
			get {

				if (this.col_EssenceID_Record == null) {
				
					this.col_EssenceID_Record = new Essence_Unite_Record(this.connectionString, this.col_EssenceID, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_EssenceID_Record);
			}
		}

		internal bool col_UniteMesureIDWasSet = false;
		private bool col_UniteMesureIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteMesureID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UniteMesureID);
			}
			set {
			
				this.col_UniteMesureIDWasUpdated = true;
				this.col_UniteMesureIDWasSet = true;
				this.col_UniteMesureID_Record = null;
				this.col_UniteMesureID = value;
			}
		}

		
		private Essence_Unite_Record col_UniteMesureID_Record = null;
		public Essence_Unite_Record Col_UniteMesureID_Essence_Unite_Record {
		
			get {

				if (this.col_UniteMesureID_Record == null) {
				
					this.col_UniteMesureID_Record = new Essence_Unite_Record(this.connectionString, System.Data.SqlTypes.SqlString.Null, this.col_UniteMesureID);
				}
				
				return(this.col_UniteMesureID_Record);
			}
		}

		internal bool col_VolumeBrutWasSet = false;
		private bool col_VolumeBrutWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_VolumeBrut = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_VolumeBrut {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VolumeBrut);
			}
			set {
			
				this.col_VolumeBrutWasUpdated = true;
				this.col_VolumeBrutWasSet = true;
				this.col_VolumeBrut = value;
			}
		}

		internal bool col_VolumeReductionWasSet = false;
		private bool col_VolumeReductionWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_VolumeReduction = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_VolumeReduction {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VolumeReduction);
			}
			set {
			
				this.col_VolumeReductionWasUpdated = true;
				this.col_VolumeReductionWasSet = true;
				this.col_VolumeReduction = value;
			}
		}

		internal bool col_VolumeNetWasSet = false;
		private bool col_VolumeNetWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_VolumeNet = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_VolumeNet {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VolumeNet);
			}
			set {
			
				this.col_VolumeNetWasUpdated = true;
				this.col_VolumeNetWasSet = true;
				this.col_VolumeNet = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_GestionVolumeIDWasUpdated = false;
			this.col_GestionVolumeIDWasSet = false;
			this.col_GestionVolumeID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_EssenceIDWasUpdated = false;
			this.col_EssenceIDWasSet = false;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;

			this.col_UniteMesureIDWasUpdated = false;
			this.col_UniteMesureIDWasSet = false;
			this.col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;

			this.col_VolumeBrutWasUpdated = false;
			this.col_VolumeBrutWasSet = false;
			this.col_VolumeBrut = System.Data.SqlTypes.SqlDouble.Null;

			this.col_VolumeReductionWasUpdated = false;
			this.col_VolumeReductionWasSet = false;
			this.col_VolumeReduction = System.Data.SqlTypes.SqlDouble.Null;

			this.col_VolumeNetWasUpdated = false;
			this.col_VolumeNetWasSet = false;
			this.col_VolumeNet = System.Data.SqlTypes.SqlDouble.Null;

			Params.spS_GestionVolume_Detail Param = new Params.spS_GestionVolume_Detail(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_GestionVolume_Detail Sp = new SPs.spS_GestionVolume_Detail();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_GestionVolumeID.ColumnIndex)) {

						this.col_GestionVolumeID = sqlDataReader.GetSqlInt32(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_GestionVolumeID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = sqlDataReader.GetSqlString(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_UniteMesureID.ColumnIndex)) {

						this.col_UniteMesureID = sqlDataReader.GetSqlString(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_UniteMesureID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_VolumeBrut.ColumnIndex)) {

						this.col_VolumeBrut = sqlDataReader.GetSqlDouble(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_VolumeBrut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_VolumeReduction.ColumnIndex)) {

						this.col_VolumeReduction = sqlDataReader.GetSqlDouble(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_VolumeReduction.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_VolumeNet.ColumnIndex)) {

						this.col_VolumeNet = sqlDataReader.GetSqlDouble(SPs.spS_GestionVolume_Detail.Resultset1.Fields.Column_VolumeNet.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.GestionVolume_Detail_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_GestionVolumeIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EssenceIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UniteMesureIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeBrutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeReductionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeNetWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_GestionVolume_Detail Param = new Params.spU_GestionVolume_Detail(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_GestionVolumeIDWasUpdated) {

				Param.Param_GestionVolumeID = this.col_GestionVolumeID;
				Param.Param_ConsiderNull_GestionVolumeID = true;
			}

			if (this.col_EssenceIDWasUpdated) {

				Param.Param_EssenceID = this.col_EssenceID;
				Param.Param_ConsiderNull_EssenceID = true;
			}

			if (this.col_UniteMesureIDWasUpdated) {

				Param.Param_UniteMesureID = this.col_UniteMesureID;
				Param.Param_ConsiderNull_UniteMesureID = true;
			}

			if (this.col_VolumeBrutWasUpdated) {

				Param.Param_VolumeBrut = this.col_VolumeBrut;
				Param.Param_ConsiderNull_VolumeBrut = true;
			}

			if (this.col_VolumeReductionWasUpdated) {

				Param.Param_VolumeReduction = this.col_VolumeReduction;
				Param.Param_ConsiderNull_VolumeReduction = true;
			}

			if (this.col_VolumeNetWasUpdated) {

				Param.Param_VolumeNet = this.col_VolumeNet;
				Param.Param_ConsiderNull_VolumeNet = true;
			}

			SPs.spU_GestionVolume_Detail Sp = new SPs.spU_GestionVolume_Detail();
			if (Sp.Execute(ref Param)) {

				this.col_GestionVolumeIDWasUpdated = false;
				this.col_EssenceIDWasUpdated = false;
				this.col_UniteMesureIDWasUpdated = false;
				this.col_VolumeBrutWasUpdated = false;
				this.col_VolumeReductionWasUpdated = false;
				this.col_VolumeNetWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.GestionVolume_Detail_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_GestionVolume_Detail_Display Param = new Params.spS_GestionVolume_Detail_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_GestionVolume_Detail_Display Sp = new SPs.spS_GestionVolume_Detail_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume_Detail_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_GestionVolume_Detail_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.GestionVolume_Detail_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
