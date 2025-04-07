//vite.config.ts
import { defineConfig } from "vite";
import react from "@vitejs/plugin-react-swc";

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      "/api": {
        target: "http://13.201.166.186:5222",
        changeOrigin: true,
      },
    },
  },
  envPrefix: "VITE_", // Ensure this prefix is correct
});
