//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'category_write.g.dart';

abstract class CategoryWrite implements Built<CategoryWrite, CategoryWriteBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'sortOrder')
    int get sortOrder;

    @BuiltValueField(wireName: r'categoryColorId')
    String get categoryColorId;

    @BuiltValueField(wireName: r'categoryShapeId')
    String get categoryShapeId;

    CategoryWrite._();

    static void _initializeBuilder(CategoryWriteBuilder b) => b;

    factory CategoryWrite([void updates(CategoryWriteBuilder b)]) = _$CategoryWrite;

    @BuiltValueSerializer(custom: true)
    static Serializer<CategoryWrite> get serializer => _$CategoryWriteSerializer();
}

class _$CategoryWriteSerializer implements StructuredSerializer<CategoryWrite> {

    @override
    final Iterable<Type> types = const [CategoryWrite, _$CategoryWrite];
    @override
    final String wireName = r'CategoryWrite';

    @override
    Iterable<Object> serialize(Serializers serializers, CategoryWrite object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'sortOrder')
            ..add(serializers.serialize(object.sortOrder,
                specifiedType: const FullType(int)));
        result
            ..add(r'categoryColorId')
            ..add(serializers.serialize(object.categoryColorId,
                specifiedType: const FullType(String)));
        result
            ..add(r'categoryShapeId')
            ..add(serializers.serialize(object.categoryShapeId,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    CategoryWrite deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CategoryWriteBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'sortOrder':
                    result.sortOrder = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'categoryColorId':
                    result.categoryColorId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'categoryShapeId':
                    result.categoryShapeId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

