import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
  plugins: [react()],
  server: {
    watch: {
      usePolling: true, // Isso resolve 99% dos problemas de "não atualiza" no Windows
    },
  },
})