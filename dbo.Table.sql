CREATE TABLE [Base].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ФИО] NVARCHAR(50) NOT NULL, 
    [Марка] NVARCHAR(50) NOT NULL, 
    [Модель] NVARCHAR(50) NOT NULL, 
    [Год] NVARCHAR(50) NOT NULL, 
    [Работы] NVARCHAR(50) NOT NULL, 
    [Стоимость] NVARCHAR(50) NOT NULL, 
    [Дата заказа] DATE NOT NULL
)
