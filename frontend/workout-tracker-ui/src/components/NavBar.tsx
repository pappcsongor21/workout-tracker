import { FaTable } from "react-icons/fa6"
import { Link } from "react-router-dom"

const NavBar = () => {
  return (
    <nav className="bg-emerald-700 text-white px-6 py-4 flex justify-between items-center shadow-md border-b-2 border-emerald-800
    lg:h-24 lg:pr-12 lg:pl-6">

        <FaTable className="text-emerald-300 text-2xl font-light
        lg:text-3xl"/>

        <div className="flex items-center gap-2 mx-auto">
          <Link to="/" className="text-2xl font-black tracking-wider uppercase text-white hover:opacity-90 transition-opacity
          lg:text-3xl">
            Workout Tracker
          </Link>
        </div>

        <div className="flex gap-4">
          <Link
            to="/workout/start"
            className={`px-4 py-2 rounded-lg text-lg font-bold transition duration-100 hover:bg-lime-300 hover:text-black`}
          >
            Start workout
          </Link>
        </div>
      </nav>
  )
}

export default NavBar