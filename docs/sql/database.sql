CREATE TABLE IF NOT EXISTS state
(
    id     INT AUTO_INCREMENT,
    `name` VARCHAR(200) NOT NULL,
    PRIMARY KEY (id)
);

-- pending , delivered

create table sale_status
(
    id     INT AUTO_INCREMENT,
    `name` VARCHAR(200) NOT NULL,
    PRIMARY KEY (id)
);


CREATE TABLE IF NOT EXISTS products
(
    id         INT AUTO_INCREMENT,
    `name`     VARCHAR(200)   NOT NULL,
    price      DECIMAL(15, 2) NOT NULL,
    cost       DECIMAL(15, 2) NOT NULL,
    state_id   INT            NOT NULL,
    stock      INT            NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME  DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (state_id) REFERENCES state (id),
    PRIMARY KEY (id)
);


CREATE TABLE IF NOT EXISTS sales
(
    id             INT(11) AUTO_INCREMENT,
    total_amount   DECIMAL(15, 2) NOT NULL,
    sub_total_amount   DECIMAL(15, 2) NOT NULL,
    iva_amount   DECIMAL(15, 2) NOT NULL,
    sale_status_id INT            NOT NULL,
    created_at     TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at     DATETIME  DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (sale_status_id) REFERENCES sale_status (id),
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS sales_details
(
    id             INT AUTO_INCREMENT,
    sales_id       INT            NOT NULL,
    product_id     INT            NOT NULL,
    price_per_unit DECIMAL(15, 2) NOT NULL,
    quantity_sold  INT            NOT NULL,
    iva_amount     DECIMAL(15, 2) NOT NULL,
    created_at     TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at     DATETIME  DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (sales_id) REFERENCES sales (id),
    FOREIGN KEY (product_id) REFERENCES products (id),
    PRIMARY KEY (id)
);


