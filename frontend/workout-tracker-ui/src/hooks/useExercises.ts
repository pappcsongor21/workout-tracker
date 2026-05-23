import { useQuery } from "@tanstack/react-query"
import type { Exercise } from "../types/exercise"

export const useExercises = () => {
  return useQuery({
    queryKey: ['exercises'],
    queryFn: async (): Promise<Exercise[]> =>{
        const res = await fetch('/api/Exercises');
        if(!res.ok){
            throw new Error('Error fetching exercises.')
        }
        return res.json();
    }
  })
}
export default useExercises