package exam.model.registry;

import java.time.LocalDate;
import java.util.List;

public interface RegistryItem {
    public void setId(long id);
    public void setCommands(String command);
    public List<String> getCommands(long Id);
    public void setName(String name);
    public void setBirthday(LocalDate birthday);
    public long getId();
    public LocalDate getBirthday();
}
