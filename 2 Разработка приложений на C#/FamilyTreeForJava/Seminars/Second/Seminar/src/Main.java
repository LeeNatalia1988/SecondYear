import org.json.simple.JSONObject;
public class Main {
    public static void main(String[] args) {
        JSONObject resultJson = new JSONObject();

        resultJson.put("name", "foo");
        System.out.print(resultJson.toString());
    }
}
