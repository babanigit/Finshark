import { defineConfig } from "vite";
import react from "@vitejs/plugin-react-swc";

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  envPrefix: "VITE_", // Ensure this prefix is correct
  server: {
    proxy: {
      "/api": {
        target: "http://localhost:5222",
        changeOrigin: true,
      },
    },
  },
});
