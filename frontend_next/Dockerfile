# Etapa 1: build de React
FROM node:25-alpine3.21 AS build

WORKDIR /app

# Copiar dependencias
COPY package*.json ./

# Instalar dependencias base
RUN npm install

# Instalar TailwindCSS + nuevo plugin PostCSS + Autoprefixer
RUN npm install -D tailwindcss @tailwindcss/postcss postcss autoprefixer

# Crear archivo Tailwind config
RUN echo 'export default { content: ["./index.html", "./src/**/*.{js,ts,jsx,tsx}"], theme: { extend: {} }, plugins: [], }' > tailwind.config.js

# Crear archivo PostCSS config (usando el nuevo paquete)
RUN echo 'export default { plugins: { "@tailwindcss/postcss": {}, autoprefixer: {}, }, }' > postcss.config.js


# Copiar el resto del código fuente
COPY . .

# Compilar la app
RUN npm run build

# Etapa 2: servir con Nginx
FROM nginx:stable-alpine

COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /app/dist /usr/share/nginx/html

EXPOSE 3000
CMD ["nginx", "-g", "daemon off;"]
