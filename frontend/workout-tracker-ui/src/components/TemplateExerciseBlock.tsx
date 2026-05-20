import type { TemplateExerciseProps } from "../types/workoutTemplate"

const TemplateExerciseBlock = ({templateExercise}:TemplateExerciseProps) => {
  return (
    <div className="grid grid-cols-4 hover:bg-gray-300">
        <div className="my-auto">
            {templateExercise.exercise.name}
        </div>
        <div >
            {templateExercise.targetSets} X {templateExercise.targetRepsMin}-{templateExercise.targetRepsMax}
        </div>
        <div >
            {templateExercise.targetIntensity}
        </div>
        <div >
            {templateExercise.restSeconds}s rest
        </div>
    </div>
  )
}

export default TemplateExerciseBlock