package exam.model.animal;

import exam.model.registry.RegistryItem;

import java.time.LocalDate;
import java.util.Comparator;

public class AnimalComparatorByBirthday implements Comparator<RegistryItem> {
    @Override
    public int compare(RegistryItem o1, RegistryItem o2) {
        return o1.getBirthday().compareTo(o2.getBirthday());
    }
}
