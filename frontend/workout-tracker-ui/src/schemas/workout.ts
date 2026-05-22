import * as z from 'zod';

export const createWorkoutTemplateSchema = z.object({
    name: z.string().trim()
    .min(1, 'Template name is required.')
    .max(25, 'Name is too long.'),
    colorHex: z.string().regex(/^#[0-9A-Fa-f]{6}$/, 'invalid color code.'),

    exercises: z.array(
        z.object({
            exerciseId: z.number().min(1, 'Choose an exercise!'),

            targetSets: z.number().min(1, 'Minimum 1 set.'),
            targetRepsMin: z.number().min(1, 'Minimum 1 repetition.'),
            targetRepsMax: z.number().min(1, 'Minimum 1 repetition.'),

            targetIntensity: z.string().trim().optional(),
            restSeconds: z.number().min(0, 'Rest time cannot be negative.')
        }).refine((exercise) => exercise.targetRepsMax >= exercise.targetRepsMin, {
          message: 'Maximum reps cannot be less than minimum reps!',
          path: ['targetRepsMax'],
        })
    )
});

export type CreateWorkoutTemplateFormData = z.infer<typeof createWorkoutTemplateSchema>;