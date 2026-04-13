//vite.config.ts
import { defineConfig } from "vite";
import react from "@vitejs/plugin-react-swc";

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  // server: {
  //   proxy: {
  //     "/api": {
  //       target: "https://finshark-api-gwn0.onrender.com/",
  //       changeOrigin: true,
  //     },
  //   },
  // },
  envPrefix: "VITE_", // Ensure this prefix is correct
});
