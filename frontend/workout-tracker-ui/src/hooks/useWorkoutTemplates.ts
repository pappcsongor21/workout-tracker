import { useMutation, useQueryClient } from "@tanstack/react-query"
import type { CreateWorkoutTemplateFormData } from "../schemas/workout";

export const useCreateWorkoutTemplate = () => {
  
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (data: CreateWorkoutTemplateFormData) =>{
      const res = await fetch('/api/WorkoutTemplates', {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(data),
      });

      if(!res.ok) throw new Error('Failed to create template');
      return res.json();
    },
    onSuccess: () => {
      queryClient.invalidateQueries({queryKey: ['workoutTemplates']});
    }
  })
}