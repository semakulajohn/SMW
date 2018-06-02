CREATE TABLE [dbo].[Property]
(
	[PropertyId] 	BIGINT IDENTITY(1,1) NOT NULL,		 
	[Description]		NVARCHAR(MAX) NOT NULL,
	[Location]		NVARCHAR(MAX) NOT NULL,
	[PropertyTypeId]        BIGINT NOT NULL,
	[MediaFolderId]  BIGINT NOT NULL,	
	[PropertyFee]		FLOAT NOT NULL,
    [CreatedOn]		DATETIME NOT NULL, 
    [Timestamp]		DATETIME NOT NULL,
	[CreatedBy]		nvarchar (128) not null,
	[UpdatedBy]		nvarchar (128) null,
	[Deleted]		BIT NOT NULL,
	[DeletedBy]		nvarchar (128) null,
	[DeletedOn]		DATETIME NULL,
	

	 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED ([PropertyId] ASC),
	CONSTRAINT [FK_dbo_Property_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[AspNetUsers](Id),
	CONSTRAINT [FK_dbo_Property_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[AspNetUsers](Id),
	CONSTRAINT [FK_dbo_Property_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[AspNetUsers](Id),
	CONSTRAINT [FK_dbo_Property_MediaId] FOREIGN KEY  ([MediaFolderId]) REFERENCES [dbo].[Media](MediaId),
	CONSTRAINT [FK_dbo_Property_PropertyTypeId] FOREIGN KEY  ([PropertyTypeId]) REFERENCES [dbo].[PropertyType](PropertyTypeId)
	
)
GO
ALTER TABLE [dbo].[Property] ADD  CONSTRAINT [DF_dbo_Property_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
