using System.Runtime.InteropServices;

namespace RaumfahrtMission
{
    public static class SpeicherVisualisierer
    {
        public static void VisualisiereSpeicher(params object[] obj)
        {
            Console.WriteLine("========= Darstellung =========");
            foreach (var ob in obj){
                Console.WriteLine(
                    $"Typ: {ob?.GetType().Name ?? "null"} | " + 
                    $"Wert: {ob} |" +
                    $"HashCode: {ob?.GetHashCode() ?? 0}");
            }
            Console.WriteLine("================================");
        }
        public static void ZeigeSpeicherInhaltUnsafe(object obj)
        {
            if (obj == null)
            {
                Console.WriteLine("Objekt ist null.");
                return;
            }

            int size = Marshal.SizeOf(obj);
            byte[] buffer = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(obj, ptr, false);
                Marshal.Copy(ptr, buffer, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            Console.WriteLine($"=== Hex-Dump für {obj.GetType().Name} (Größe: {size} Bytes) ===");
            for (int i = 0; i < buffer.Length; i += 8)
            {
                Console.Write($"{i:X4}: ");
                for (int j = 0; j < 8 && (i + j) < buffer.Length; j++)
                {
                    Console.Write($"{buffer[i + j]:X2} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("==========================================");
        }
    }
}