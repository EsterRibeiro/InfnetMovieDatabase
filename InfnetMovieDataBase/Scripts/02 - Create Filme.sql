USE InfnetMovieDataBase;

CREATE TABLE [dbo].[Filme] (
    [Id]				INT           NOT NULL PRIMARY KEY IDENTITY,
    [Titulo]			VARCHAR (255) NULL,
    [TituloOriginal]    VARCHAR (255) NULL,
    [Ano]				INT			  NULL,
	[Duracao]			INT			  NULL,
);

INSERT INTO [dbo].[Filme] (Titulo, TituloOriginal, Ano, Duracao) VALUES ('Rocky: Um Lutador', 'Rocky', 1976, 120);
INSERT INTO [dbo].[Filme] (Titulo, TituloOriginal, Ano, Duracao) VALUES ('O Exterminador do Futuro', 'Terminator', 1984, 107);
INSERT INTO [dbo].[Filme] (Titulo, TituloOriginal, Ano, Duracao) VALUES ('Alien, o Oitavo Passageiro', 'Alien', 1979,117);
INSERT INTO [dbo].[Filme] (Titulo, TituloOriginal, Ano, Duracao) VALUES ('Police Story: A Guerra das Drogas', 'Ging chaat goo si', 1985, 100);
INSERT INTO [dbo].[Filme] (Titulo, TituloOriginal, Ano, Duracao) VALUES ('Os Mercenários', 'The Expendables', 2010, 103);