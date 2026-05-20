import { Link } from "react-router-dom"

const NavBar = () => {
  return (
    <nav className="bg-emerald-700 text-white px-6 py-4 flex justify-between items-center shadow-md border-b-2 border-emerald-800">
        <div className="flex items-center gap-2 mx-auto">
          <Link to="/" className="text-2xl font-black tracking-wider uppercase text-white hover:opacity-90 transition-opacity">
            Workout Tracker
          </Link>
        </div>
      </nav>
  )
}

export default NavBar