import org.json.simple.JSONObject;
public class task1 {
    public static void main(String[] args) {
        JSONObject filterJson = new JSONObject();
        filterJson.put("name", "Ivanov");
        filterJson.put("country", "Russia");
        filterJson.put("city", "Moscow");
        filterJson.put("age", null);

        StringBuilder whereClause = new StringBuilder("SELECT * FROM students WHERE");

        if (filterJson.get("name") != null) {
            whereClause.append(" name = '").append(filterJson.get("name")).append("' AND");
        }

        if (filterJson.get("country") != null) {
            whereClause.append(" country = '").append(filterJson.get("country")).append("' AND");
        }

        if (filterJson.get("city") != null) {
            whereClause.append(" city = '").append(filterJson.get("city")).append("' AND");
        }

        if (filterJson.get("age") != null) {
            whereClause.append(" age = ").append(filterJson.get("age")).append(" AND");
        }

        if (whereClause.toString().endsWith(" AND")) {
            whereClause.delete(whereClause.length() - 4, whereClause.length());
        }

        System.out.println(whereClause.toString());
    }
}
