create database ZapateriaAresDB;

use ZapateriaAresDB;

CREATE TABLE Categorias (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255)
);

-- Tabla Productos
CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(500),
    Precio DECIMAL(10,2) NOT NULL,
    ImagenUrl NVARCHAR(255),
    CategoriaId INT FOREIGN KEY REFERENCES Categorias(Id)
);

-- Insertar categorías de zapatos
INSERT INTO Categorias (Nombre, Descripcion) VALUES
('Deportivos', 'Zapatos para actividades deportivas y ejercicio'),
('Casuales', 'Zapatos para uso diario y casual'),
('Formales', 'Zapatos elegantes para ocasiones especiales'),
('Botas', 'Calzado tipo bota para diferentes ocasiones'),
('Sandalias', 'Calzado abierto para clima cálido');

-- Insertar productos de ejemplo
INSERT INTO Productos (Nombre, Descripcion, Precio, ImagenUrl, CategoriaId) VALUES
-- Deportivos
('Nike Air Max 270', 'Tenis deportivos con tecnología Air Max para máxima comodidad', 2500.00, 'https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/4f37fca8-6bce-43e7-ad07-f57ae3c13142/air-max-270-mens-shoes-KkLcGR.png', 1),
('Adidas Ultraboost 22', 'Tenis de running con amortiguación superior', 3200.00, 'https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/fbaf991a78bc4896a3e9ad7800abcec6_9366/Ultraboost_22_Shoes_Black_GZ0127_01_standard.jpg', 1),
('Puma RS-X', 'Tenis retro con diseño futurista', 1800.00, 'https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_2000,h_2000/global/374393/11/sv01/fnd/PNA/fmt/png/RS-X-Puzzle-Sneakers', 1),

-- Casuales
('Converse Chuck Taylor', 'Clásicos tenis casuales de lona', 1200.00, 'https://www.converse.com/dw/image/v2/BCZC_PRD/on/demandware.static/-/Sites-cnv-master-catalog/default/dw2f8f0b2f/images/a_08/M9160_A_08X1.jpg', 2),
('Vans Old Skool', 'Tenis clásicos con diseño icónico', 1400.00, 'https://images.vans.com/is/image/Vans/D3HY28-HERO?$583x583$', 2),
('Sketchers Go Walk', 'Tenis ultraligeros para caminar', 1600.00, 'https://skechers.com.mx/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/2/1/216011_bbk.jpg', 2),

-- Formales
('Clarks Desert Boot', 'Botas formales de cuero genuino', 2800.00, 'https://www.clarks.com/dw/image/v2/ABJK_PRD/on/demandware.static/-/Sites-clarks-master-catalog/default/dw3f2c6d53/images/c/26138221_1.jpg', 3),
('Cole Haan Oxford', 'Zapatos Oxford clásicos para oficina', 3500.00, 'https://www.colehaan.com/dw/image/v2/AALO_PRD/on/demandware.static/-/Sites-itemmaster_colehaan/default/dw0f3a5f8b/images/items/C26514_A.jpg', 3),

-- Botas
('Timberland 6-Inch', 'Botas resistentes para trabajo y aventura', 4200.00, 'https://www.timberland.com/dw/image/v2/ABDN_PRD/on/demandware.static/-/Sites-timberland-master-catalog/default/dw6f7f6a8f/images/model/10061024-HERO.jpg', 4),
('Dr. Martens 1460', 'Botas clásicas de cuero con estilo único', 3800.00, 'https://i1.adis.ws/i/drmartens/11822006.88.jpg', 4),

-- Sandalias
('Birkenstock Arizona', 'Sandalias ergonómicas con plantilla de corcho', 2200.00, 'https://www.birkenstock.com/dw/image/v2/BDCB_PRD/on/demandware.static/-/Sites-master-catalog/default/dw8f0a5f5b/images/051793/051793_pair_large.jpg', 5),
('Havaianas Top', 'Sandalias brasileñas de goma', 450.00, 'https://havaianas.com.mx/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/4/0/4000029_0090_1.jpg', 5);

-- Verificar que se crearon las tablas correctamente
SELECT * FROM Categorias;
SELECT * FROM Productos;

-- Verificar relaciones
SELECT p.Nombre as Producto, c.Nombre as Categoria, p.Precio 
FROM Productos p 
INNER JOIN Categorias c ON p.CategoriaId = c.Id;


